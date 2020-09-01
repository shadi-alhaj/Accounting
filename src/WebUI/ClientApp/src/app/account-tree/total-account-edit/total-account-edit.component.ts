import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AccountTreeService } from '../account-tree.service';
import { TotalAccountsClient, MainAccountsClient, CreateTotalAccountCommand } from 'src/app/accounting-api';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-total-account-edit',
  templateUrl: './total-account-edit.component.html',
  styleUrls: ['./total-account-edit.component.css']
})
export class TotalAccountEditComponent implements OnInit {
  errorMessages = {};
  @ViewChild('mainAccountNameAr', { static: false }) nameFiled: ElementRef;

  constructor(public accountTreeSvc: AccountTreeService,
    private totalAccountsClient: TotalAccountsClient,
    private mainAccountsClient: MainAccountsClient,
    private dialogRef: MatDialogRef<TotalAccountEditComponent>,
    private dialog: MatDialog) { }

  ngOnInit() {
  }

  getMainAndTotalAccount(id) {
    let mainAccountExist = false;
    this.mainAccountsClient.mainAccount(id, this.accountTreeSvc.customerId)
      .subscribe(
        result => {
          if (result !== null) {
            mainAccountExist = true;
            this.accountTreeSvc.totalAccountForm.patchValue({
              mainAccountId: result.id,
              mainAccountNameAr: result.mainAccountNameAr,
              generalLeadgerId: result.generalLeadgerId
            });
          }
        },
        error => {
          console.log(error);
        }, () => {
          if (mainAccountExist) {
            this.getMaxTotalAccountIdByCustomer(this.accountTreeSvc.customerId, id);
            this.nameFiled.nativeElement.focus();
          }
        });
  }
  getMaxTotalAccountIdByCustomer(customerId: any, glCustomerId: any) {
    this.totalAccountsClient.maxTotalAccountIdByCustomer(customerId, glCustomerId).subscribe(
      result => {
        this.accountTreeSvc.totalAccountForm.patchValue({
          totalAccountIdByCustomer: result
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
    if (this.accountTreeSvc.selectedTotalAccount === null) {
      this.addNewTotalAccount();
    } else {
      this.updateTotalAccount();
    }
  }
  updateTotalAccount() {
    throw new Error("Method not implemented.");
  }
  addNewTotalAccount() {
    let hasError = false;
    this.totalAccountsClient.createTotalAccount(CreateTotalAccountCommand.fromJS(this.accountTreeSvc.totalAccountForm.value))
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
