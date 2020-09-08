import { BondsClient, DetailAccountsClient } from 'src/app/accounting-api';
import { DailyTransactionService } from './../daily-transaction.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-daily-transaction-edit',
  templateUrl: './daily-transaction-edit.component.html',
  styleUrls: ['./daily-transaction-edit.component.css']
})
export class DailyTransactionEditComponent implements OnInit {

  pageTitle = 'Daily Transaction';
  @ViewChild('bondDate', { static: false }) bondDateFiled: ElementRef;

  constructor(public dailyTransactionSvc: DailyTransactionService,
              private bondsClient: BondsClient,
              private detailAccountsClient: DetailAccountsClient) { }

  ngOnInit() {
  }

  onSubmit() { }

  getBondInfo(bondUserId: number): void {
    this.bondsClient.bondByCustomerIdAndBondCustomerIdQuery(this.dailyTransactionSvc.customerId, 
      bondUserId, this.dailyTransactionSvc.financeYear)
      .subscribe(
        result => {
          if (result) {
            this.dailyTransactionSvc.dailyTransactionForm.patchValue({
              bondId: result.bondId,
              bondName: result.bondNameAr,
              bondSno: result.bondMaxSNo
            });
            this.bondDateFiled.nativeElement.focus();
          }
        },
        error => {
          console.log(error);
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            bondId: '',
            bondName: '',
            bondSno: null
          });
        });
  }

  getDetailAccountInfo(detailAccountIdByCustomer){
    this.detailAccountsClient.detailAccount(this.dailyTransactionSvc.customerId, detailAccountIdByCustomer)
    .subscribe(
      result => {
        if(result){
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            detailAccountNameAr: result.detailAccountNameAr,
            detailAccountNameEn: result.detailAccountNameEn,
            generalLedgerId: result.generalLeadgerId,
            mainAccountId: result.mainAccountId,
            totalAccountId: result.totalAccountId,
            detailAccountId: result.id,
            dailyTransactionYear: this.dailyTransactionSvc.financeYear,
          });
        } 
      },
      error => {
        console.log(error);        
      });
  }

}
