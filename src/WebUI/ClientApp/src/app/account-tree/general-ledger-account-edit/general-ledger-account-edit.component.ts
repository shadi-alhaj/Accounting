import { AccountTreeService } from './../account-tree.service';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { GeneralLedgersClient, CreateGeneralLedgerCommand, UpdateGeneralLedgerCommand } from 'src/app/accounting-api';

@Component({
  selector: 'app-general-ledger-account-edit',
  templateUrl: './general-ledger-account-edit.component.html',
  styleUrls: ['./general-ledger-account-edit.component.css']
})
export class GeneralLedgerAccountEditComponent implements OnInit {

  errorMessages = {};

  constructor(public accountTreeSvc: AccountTreeService,
              private dialogRef: MatDialogRef<GeneralLedgerAccountEditComponent>,
              private glsClient: GeneralLedgersClient) { }

  ngOnInit() {
  }

  onClose(){
    this.dialogRef.close();
  }

  onSubmit(){
    if(this.accountTreeSvc.selectedGl === null){
      this.addNewGl();
    }else{
      this.updateGl();
    }
  }
  updateGl() {
    let hasError = false;
    this.glsClient.updateGeneralLedger(this.accountTreeSvc.selectedGl, UpdateGeneralLedgerCommand.fromJS(this.accountTreeSvc.glForm.value))
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
  addNewGl() {
    let hasError = false;
    this.glsClient.createGeneralLedger(CreateGeneralLedgerCommand.fromJS(this.accountTreeSvc.glForm.value))
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
