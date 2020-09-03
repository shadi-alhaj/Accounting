import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AccountTreeService } from '../account-tree.service';
import { TotalAccountsClient, DetailAccountsClient, CreateDetailAccountCommand, UpdateDetailAccountCommand } from 'src/app/accounting-api';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-detail-account-edit',
  templateUrl: './detail-account-edit.component.html',
  styleUrls: ['./detail-account-edit.component.css']
})
export class DetailAccountEditComponent implements OnInit {

  errorMessages = {};
  @ViewChild('mainAccountNameAr', { static: false }) nameFiled: ElementRef;

  constructor(public accountTreeSvc: AccountTreeService,
    private detailAccountsClient: DetailAccountsClient,
    private totalAccountsClient: TotalAccountsClient,
    private dialogRef: MatDialogRef<DetailAccountEditComponent>,
    private dialog: MatDialog) { }

  ngOnInit() {
  }

  getTotalAndDetailAccount(totalAccountIdByCustomer) {
    let totalAccountExist = false;
    this.totalAccountsClient.totalAccount(totalAccountIdByCustomer, this.accountTreeSvc.customerId)
      .subscribe(
        result => {
          if (result !== null) {
            totalAccountExist = true;
            this.accountTreeSvc.detailAccountForm.patchValue({
              totalAccountId: result.id,
              totalAccountNameAr: result.totalAccountNameAr,
              generalLeadgerId: result.generalLeadgerId,
              mainAccountId: result.mainAccountId
            });
          }
        },
        error => {
          console.log(error);
        }, () => {
          if (totalAccountExist) {
            this.getMaxDetailAccountIdByCustomer(this.accountTreeSvc.customerId, totalAccountIdByCustomer);
            this.nameFiled.nativeElement.focus();
          }
        });
  }

  getMaxDetailAccountIdByCustomer(customerId: any, totalAccountIdByCustomer: any) {
    this.detailAccountsClient.maxDetailAccountIdByCustomer(customerId, totalAccountIdByCustomer).subscribe(
      result => {
        this.accountTreeSvc.detailAccountForm.patchValue({
          detailAccountIdByCustomer: result
        });
      },
      error => {
        console.log(error);
      });
  }

  onClose() {
    this.dialogRef.close();
  }

  onSubmit() {
    //console.log(this.accountTreeSvc.detailAccountForm.value);
    
    if (this.accountTreeSvc.selectedDetailAccount === null) {
      this.addNewDetailAccount();
    } else {
      this.updateDetailAccount();
    }
  }

  updateDetailAccount() {
    let hasError = false;
    this.detailAccountsClient.updateDetailAccount(this.accountTreeSvc.selectedDetailAccount,
      UpdateDetailAccountCommand.fromJS(this.accountTreeSvc.detailAccountForm.value))
      .subscribe(result => {
      },
        error => {
          this.errorMessages = JSON.parse(error.response);
          hasError = true;
        },
        () => {
          if (!hasError) {
            this.onClose();
          }
        });
  }

  addNewDetailAccount() {
    let hasError = false;
    this.detailAccountsClient.createDetailAccount(CreateDetailAccountCommand.fromJS(this.accountTreeSvc.detailAccountForm.value))
      .subscribe(result => {
      },
        error => {
          this.errorMessages = JSON.parse(error.response);
          hasError = true;
        },
        () => {
          if (!hasError) {
            this.onClose();
          }
        });
  }

}
