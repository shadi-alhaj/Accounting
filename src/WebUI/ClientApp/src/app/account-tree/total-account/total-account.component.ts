import { MatPaginator } from '@angular/material/paginator';
import { Component, OnInit, ViewChild } from '@angular/core';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';
import { MatTableDataSource } from '@angular/material/table';
import { TotalAccountVm, TotalAccountsClient } from 'src/app/accounting-api';
import { AccountTreeService } from '../account-tree.service';
import { MatDialog } from '@angular/material/dialog';
import { TotalAccountEditComponent } from '../total-account-edit/total-account-edit.component';

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
    private dialog: MatDialog) { }

  ngOnInit() {
    this.getTotalAccountList();
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

  onEdit(totalAccount) { }

  onDelete(id) { }

}
