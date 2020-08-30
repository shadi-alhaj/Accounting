import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { BondService } from './../bond.service';
import { BondEditComponent } from './../bond-edit/bond-edit.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { BondVm, BondsClient } from 'src/app/accounting-api';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-bond-list',
  templateUrl: './bond-list.component.html',
  styleUrls: ['./bond-list.component.css']
})
export class BondListComponent implements OnInit {
  pageTitle = 'Bond List';
  customerId = null;


  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;

  bondList: BondVm;
  displayedColumns = ['bondUserId', 'bondNameAr', 'bondNameEn', 'intialSNo', 'actions'];
  dataSource: MatTableDataSource<BondVm>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private bondsClient: BondsClient,
    private dialog: MatDialog,
    private bondSvc: BondService,
    private confirmationSvc: ConfirmationService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    const customer = JSON.parse(localStorage.getItem('customer'));
    this.customerId = customer.cusId;
    this.getBondList();
  }

  getBondList() {
    this.bondsClient.bonds(this.customerId).subscribe(
      result => {
        this.dataSource = new MatTableDataSource(result.lists);
        setTimeout(() => this.dataSource.paginator = this.paginator);
      },
      error => {
        console.log(error);
      });
  }

  GetBondMaxIdByCustomerId() {
    this.bondsClient.getBondMaxIdByCustomerId(this.customerId).subscribe(
      result => {
        this.bondSvc.bondForm.patchValue({
          bondUserId: result
        });
      },
      error => {
        console.log(error);
      });
  }

  openBondDetails() {
    this.bondSvc.bondForm.patchValue({
      customerId: this.customerId
    });    
    this.dialog.open(BondEditComponent, {
      width: '50%'
    })
    .afterClosed()
    .subscribe(
      () => {this.getBondList();
      });
  }

  onCreate() {
    this.bondSvc.selectedBond = null;
    this.bondSvc.intializeBondForm();
    this.GetBondMaxIdByCustomerId();
    this.openBondDetails();
  }

  onEdit(bond) {
    console.log(bond);
    this.bondSvc.selectedBond = bond.id;
    this.bondSvc.bondForm.patchValue(bond);
    this.openBondDetails();
  }

  onDelete(id) {
    this.confirmationSvc
    .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Bond')
    .afterClosed()
    .subscribe(
      result => {
        if(result){
          this.bondsClient.deleteBond(id).subscribe(
            result => {
              this.snackBar.open('Record has been deleted successfully!', 'Delete', {
                duration: 2000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.getBondList();
            },
            error => {
              console.log(error);
            });
        }
      });
  }

}
