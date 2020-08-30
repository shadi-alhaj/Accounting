import { AccountTreeService } from './../account-tree.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { GeneralLedgerVm, MainAccountsClient, MainAccountVm } from 'src/app/accounting-api';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { MainAccountEditComponent } from '../main-account-edit/main-account-edit.component';

@Component({
  selector: 'app-main-account',
  templateUrl: './main-account.component.html',
  styleUrls: ['./main-account.component.css']
})
export class MainAccountComponent implements OnInit {
  pageTitle = 'Main Account';
 
  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;

  displayedColumns = ['mAccountIdByCustomer', 'mAccountNameAr', 'mAccountNameEn', 'glNameAr', 'actions'];
  dataSource: MatTableDataSource<MainAccountVm>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private mainAccountsClient: MainAccountsClient,
              private accountTreeSvc: AccountTreeService,
              private dialog: MatDialog,
              private confirmationSvc: ConfirmationService,
              private snackBar: MatSnackBar) { }

  ngOnInit() {    
    this.getMainAccountList();
  }

  getMainAccountList(){
    this.mainAccountsClient.mainAccounts(this.accountTreeSvc.customerId).subscribe(
      result => {
        console.log(result);
        
        this.dataSource = new MatTableDataSource(result.lists);
        setTimeout(() => this.dataSource.paginator = this.paginator);
      },
      error => {
        console.log(error);
      });
  }

  openMainAccountDetail(){
    this.accountTreeSvc.mainAccountForm.patchValue({
      customerId: this.accountTreeSvc.customerId
    }); 
    this.dialog.open(MainAccountEditComponent, {
      width: '50%'
    })
    .afterClosed()
    .subscribe(
      () => {this.getMainAccountList();
      });
  }
  onCreate(){
    this.accountTreeSvc.selectedMainAccount = null;
    this.accountTreeSvc.intializeMainAccountForm();    
    this.openMainAccountDetail();
  }

  onEdit(mainAccount){
    console.log(mainAccount);
    
    this.accountTreeSvc.intializeMainAccountForm();
    this.accountTreeSvc.selectedMainAccount = mainAccount.id;
    this.accountTreeSvc.mainAccountForm.patchValue(mainAccount);
    this.openMainAccountDetail();
  }

  onDelete(id){
    this.confirmationSvc
    .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Main Account')
    .afterClosed()
    .subscribe(
      result => {
        if(result){
          this.mainAccountsClient.deleteMainAccount(id).subscribe(
            res => {
              this.snackBar.open('Record has been deleted successfully!', 'Delete', {
                duration: 2000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.getMainAccountList();
            },
            error => {
              console.log(error);
            });
        }
      });
  }

}
