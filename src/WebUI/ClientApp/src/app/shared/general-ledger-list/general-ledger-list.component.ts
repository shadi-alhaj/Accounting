import { GeneralLedgersClient, GeneralLedgerVm } from 'src/app/accounting-api';
import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-general-ledger-list',
  templateUrl: './general-ledger-list.component.html',
  styleUrls: ['./general-ledger-list.component.css']
})
export class GeneralLedgerListComponent implements OnInit {
  pageTitle = 'General Ledger List';
  @Input() customerId;
  glVm: GeneralLedgerVm;
  constructor(private dialogRef: MatDialogRef<GeneralLedgerListComponent>,
              private glsClient: GeneralLedgersClient) { }

  ngOnInit() {
    this.glVm = new GeneralLedgerVm();
    const customer = JSON.parse(localStorage.getItem('customer'));
    this.customerId = customer.cusId;
    this.getGeneralLedgers();
  }

  onClose(){
    this.dialogRef.close();
  }

  getGeneralLedgers(){
    this.glsClient.generalLedgers(this.customerId).subscribe(
      result => {
        console.log('getGeneralLedgers');
        console.log(result);
        
        this.glVm = result;
      },
      error => {
        console.log(error);        
      });
  }

}
