import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { DetailAccountVm, DetailAccountsClient } from 'src/app/accounting-api';
import { AccountTreeService } from '../account-tree.service';
import { MatDialog } from '@angular/material/dialog';
import { DetailAccountEditComponent } from '../detail-account-edit/detail-account-edit.component';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';

@Component({
  selector: 'app-detail-account',
  templateUrl: './detail-account.component.html',
  styleUrls: ['./detail-account.component.css']
})
export class DetailAccountComponent implements OnInit {
  pageTitle = 'Details Account';

  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;

  displayedColumns = ['detailAccountIdByCustomer', 'detailAccountNameAr', 'detailAccountNameEn', 'totalAccountNameAr', 'actions'];
  dataSource: MatTableDataSource<DetailAccountVm>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

  constructor(private detailAccountsClient: DetailAccountsClient,
    private accountTreeSvc: AccountTreeService,
    private dialog: MatDialog,
    private confirmationSvc: ConfirmationService,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.getDetailAccountList();
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  getDetailAccountList() {
    this.detailAccountsClient.detailAccounts(this.accountTreeSvc.customerId).subscribe(
      result => {
        this.dataSource = new MatTableDataSource(result.lists);
      },
      error => {
        console.log(error);
      });
  }

  openDetailAccountDetail() {
    this.accountTreeSvc.detailAccountForm.patchValue({
      customerId: this.accountTreeSvc.customerId
    });

    this.dialog.open(DetailAccountEditComponent, {
      width: '50%'
    }).afterClosed()
      .subscribe(
        () => {
          this.getDetailAccountList();
        });
  }

  onCreate() {
    this.accountTreeSvc.selectedDetailAccount = null;
    this.accountTreeSvc.initalizeDetailAccountForm();
    this.openDetailAccountDetail();
  }

  onEdit(detailAccount) {
    this.accountTreeSvc.initalizeDetailAccountForm();
    this.accountTreeSvc.selectedDetailAccount = detailAccount.id;
    this.accountTreeSvc.detailAccountForm.patchValue(detailAccount);
    this.openDetailAccountDetail();
  }

  onDelete(id) {
    this.confirmationSvc
    .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Details Account')
    .afterClosed()
    .subscribe(
      result => {
        if(result){
          this.detailAccountsClient.deleteDetailAccount(id).subscribe(
            res => {
              this.snackBar.open('Record has been deleted successfully!', 'Delete Details Account', {
                duration: 2000,
                verticalPosition: 'top',
                horizontalPosition: 'center'
              });
              this.getDetailAccountList();
            },
            error => {
              console.log(error);
            });
        }
      });
   }

}
