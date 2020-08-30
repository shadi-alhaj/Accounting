import { BondsClient, CreateBondCommand, UpdateBondCommand } from 'src/app/accounting-api';
import { BondService } from './../bond.service';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-bond-edit',
  templateUrl: './bond-edit.component.html',
  styleUrls: ['./bond-edit.component.css']
})
export class BondEditComponent implements OnInit {
  errorMessages = { IntialSNo: '', BondNameAr: '', BondNameEn: '', CustomerId: '' };
  constructor(public bondSvc: BondService,
    private dialogRef: MatDialogRef<BondEditComponent>,
    private bondsClient: BondsClient) { }

  ngOnInit() {
  }

  onClose() {
    this.dialogRef.close();
  }

  onSubmit() {
    if (this.bondSvc.selectedBond === null) {
      this.addNewBond();
    } else {
      this.updateBond();
    }
  }
  updateBond() {
    let hasError = false;
    this.bondsClient.updateBond(this.bondSvc.selectedBond, UpdateBondCommand.fromJS(this.bondSvc.bondForm.value))
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
  addNewBond() {
    let hasError = false;
    this.bondsClient.createBond(CreateBondCommand.fromJS(this.bondSvc.bondForm.value))
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
