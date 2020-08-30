import { GeneralLedgersClient, MainAccountsClient, CreateMainAccountCommand } from 'src/app/accounting-api';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AccountTreeService } from '../account-tree.service';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { GeneralLedgerListComponent } from 'src/app/shared/general-ledger-list/general-ledger-list.component';

@Component({
  selector: 'app-main-account-edit',
  templateUrl: './main-account-edit.component.html',
  styleUrls: ['./main-account-edit.component.css']
})
export class MainAccountEditComponent implements OnInit {
  
  errorMessages = {};

  @ViewChild('mainAccountNameAr', { static: false }) nameFiled: ElementRef;

  constructor(public accountTreeSvc: AccountTreeService,
    private glsClient: GeneralLedgersClient,
    private mainAccountsClient: MainAccountsClient,
    private dialogRef: MatDialogRef<MainAccountEditComponent>,
    private dialog: MatDialog) { }

  ngOnInit() {
  }

  getGlAndMainAccount(glCustomerId) {
    let glExist = false;
    this.glsClient.generalLedgerByGlIdCustomerAndCustomerId(this.accountTreeSvc.customerId, glCustomerId)
      .subscribe(
        result => {
          if (result !== null) {
            glExist = true;
            this.accountTreeSvc.mainAccountForm.patchValue({
              generalLeadgerId: result.id,
              glNameAr: result.glNameAr
            });
          }
        },
        error => {
          console.log(error);
        }, () => {
          if (glExist) {
            this.getMaxMainAccountIdByCustomer(this.accountTreeSvc.customerId, glCustomerId);
            this.nameFiled.nativeElement.focus();
          }
        });
  }

  getMaxMainAccountIdByCustomer(customerId, glCustomerId) {
    this.mainAccountsClient.maxMainAccountIdByCustomer(customerId, glCustomerId).subscribe(
      result => {
        this.accountTreeSvc.mainAccountForm.patchValue({
          mainAccountIdByCustomer: result
        });
      },
      error => {
        console.log(error);
      }
    )
  }

  onClose() {
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.accountTreeSvc.selectedMainAccount === null) {
      this.addNewMainAccount();
    } else {
      this.updateMainAccount();
    }
  }
  updateMainAccount() {
    throw new Error("Method not implemented.");
  }
  addNewMainAccount() {
    console.log(this.accountTreeSvc.mainAccountForm.value);

    let hasError = false;
    this.mainAccountsClient.createMainAccount(CreateMainAccountCommand.fromJS(this.accountTreeSvc.mainAccountForm.value))
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

  onOpenGlList() {
    this.dialog.open(GeneralLedgerListComponent, {
      width: '50%'
    });
  }

}
