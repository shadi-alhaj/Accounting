import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { TotalAccountVm, TotalAccountsClient } from 'src/app/accounting-api';
import { AccountTreeService } from '../account-tree.service';
import { MatDialog } from '@angular/material/dialog';
import { TotalAccountEditComponent } from '../total-account-edit/total-account-edit.component';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';

@Component({
  selector: 'app-total-account',
  templateUrl: './total-account.component.html',
  styleUrls: ['./total-account.component.css']
})
export class TotalAccountComponent implements OnInit {
  pageTitle = 'Total Account';

  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;

  displayedColumns = ['totalAccountIdByCustomer', 'totalAccountNameAr', 'totalAccountNameEn', 'isClose', 'mainAccountNameAr', 'actions'];
  dataSource: MatTableDataSource<TotalAccountVm>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;


  constructor(private totalAccountsClient: TotalAccountsClient,
              private accountTreeSvc: AccountTreeService,
              private dialog: MatDialog,
              private confirmationSvc: ConfirmationService,
              private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getTotalAccountList();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getTotalAccountList() {
    this.totalAccountsClient
      .totalAccounts(this.accountTreeSvc.customerId)
      .subscribe(
        result => {
          console.log(result);
          this.dataSource = new MatTableDataSource(result.lists);
          setTimeout(() => this.dataSource.paginator = this.paginator);
        },
        error => {
          console.log(error);
        });
  }

  openTotalAccountDetail() {
    this.accountTreeSvc.totalAccountForm.patchValue({
      customerId: this.accountTreeSvc.customerId
    });

    this.dialog.open(TotalAccountEditComponent, {
      width: '50%'
    }).afterClosed()
      .subscribe(
        () => {
          this.getTotalAccountList();
        });
  }

  onCreate() {
    this.accountTreeSvc.selectedTotalAccount = null;
    this.accountTreeSvc.initalizeTotalAccountForm();
    this.openTotalAccountDetail();
   }

  onEdit(totalAccount) {
    this.accountTreeSvc.initalizeTotalAccountForm();
    this.accountTreeSvc.selectedTotalAccount = totalAccount.id;
    this.accountTreeSvc.totalAccountForm.patchValue(totalAccount);
    this.openTotalAccountDetail();
   }

  onDelete(id) { 
    this.confirmationSvc
    .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Total Account')
    .afterClosed()
    .subscribe(
      result => {
        if(result){
          this.totalAccountsClient.deleteTotalAccount(id).subscribe(
            res => {
              this.snackBar.open('Record has been deleted successfully!', 'Delete Total Account', {
                duration: 2000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.getTotalAccountList();
            },
            error => {
              console.log(error);
            });
        }
      });
  }

}
