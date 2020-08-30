import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { GeneralLedgerAccountEditComponent } from './../general-ledger-account-edit/general-ledger-account-edit.component';
import { AccountTreeService } from './../account-tree.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GeneralLedgerVm, GeneralLedgersClient } from 'src/app/accounting-api';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-general-ledger-account',
  templateUrl: './general-ledger-account.component.html',
  styleUrls: ['./general-ledger-account.component.css']
})
export class GeneralLedgerAccountComponent implements OnInit {
  pageTitle = 'General Ledger';

  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;

  displayedColumns = ['glIdByCustomer', 'glNameAr', 'glNameEn', 'actions'];
  dataSource: MatTableDataSource<GeneralLedgerVm>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  
  constructor(private glClients: GeneralLedgersClient,
              private accountTreeSvc: AccountTreeService,
              private dialog: MatDialog,
              private confirmationSvc: ConfirmationService,
              private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getGeneralLeadgerList();
  }

  getGeneralLeadgerList() {
    this.glClients.generalLedgers(this.accountTreeSvc.customerId).subscribe(
      result => {
        this.dataSource = new MatTableDataSource(result.lists);
        setTimeout(() => this.dataSource.paginator = this.paginator);
      },
      error => {
        console.log(error);
      });
  }

  getGlMaxIdByCustomerId() {
    this.glClients.glMaxIdByCustomerId(this.accountTreeSvc.customerId).subscribe(
      result => {
        this.accountTreeSvc.glForm.patchValue({
          glIdByCustomer: result
        });
      },
      error => {
        console.log(error);
      });
  }

  openGlDetail(){
    this.accountTreeSvc.glForm.patchValue({
      customerId: this.accountTreeSvc.customerId
    });        

    this.dialog.open(GeneralLedgerAccountEditComponent, {
      width: '50%'
    })
    .afterClosed()
    .subscribe(
      () => {this.getGeneralLeadgerList();
      });
  }

  onCreate(){
    this.accountTreeSvc.selectedGl = null;
    this.accountTreeSvc.initalizeGlForm();
    this.getGlMaxIdByCustomerId();
    this.openGlDetail();
  }

  onEdit(gl){
    this.accountTreeSvc.initalizeGlForm();
    this.accountTreeSvc.selectedGl = gl.id;
    this.accountTreeSvc.glForm.patchValue(gl);
    this.openGlDetail();
  }
  
  onDelete(id){
    this.confirmationSvc
    .openConfirmationDialog('Are you sure want to delete this record?', 'Delete General Leadger Account')
    .afterClosed()
    .subscribe(
      result => {
        if(result){
          this.glClients.deleteGeneralLedger(id).subscribe(
            res => {
              this.snackBar.open('Record has been deleted successfully!', 'Delete', {
                duration: 2000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.getGeneralLeadgerList();
            },
            error => {
              console.log(error);
            });
        }
      });
  }

}
