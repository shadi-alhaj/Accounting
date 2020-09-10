import { BondsClient, DetailAccountsClient, DailyTransactionsClient, CreateDailyTransactionCommand } from 'src/app/accounting-api';
import { DailyTransactionService } from './../daily-transaction.service';
import { Component, OnInit, ViewChild, ElementRef, QueryList, ViewChildren } from '@angular/core';

@Component({
  selector: 'app-daily-transaction-edit',
  templateUrl: './daily-transaction-edit.component.html',
  styleUrls: ['./daily-transaction-edit.component.css']
})
export class DailyTransactionEditComponent implements OnInit {

  pageTitle = 'Daily Transaction';
  @ViewChild('bondDate', { static: false }) bondDateFiled: ElementRef;
  @ViewChild('bondUserId', { static: false }) bondIdFiled: ElementRef;
  @ViewChild('dailyTransactionDebitAmount', { static: false }) dailyTransactionDebitAmount: ElementRef;
  total = 0;
  constructor(private dailyTransactionsClient: DailyTransactionsClient,
              public dailyTransactionSvc: DailyTransactionService,
              private bondsClient: BondsClient,
              private detailAccountsClient: DetailAccountsClient) { }

  ngOnInit() {

    this.dailyTransactionSvc.dailyTransactionForm.patchValue({
      customerId: this.dailyTransactionSvc.customerId,
      dailyTransactionYear: this.dailyTransactionSvc.financeYear
    });
    // this.dailyTransactionDetails.valueChanges
    // .subscribe( value => {
    //     this.total = value.reduce((sum, item) => sum += +item.dailyTransactionDebitAmount, 0);
    // })
    // console.log('total');
    // console.log(this.total);
    
    // this.dailyTransactionForm.patchValue({
    //   sumDebit: this.total
    // })
  }

  onSubmit() {
    console.log('onSubmit');
    console.log(this.dailyTransactionSvc.dailyTransactionForm.value);
    this.dailyTransactionsClient
      .createDailyTransaction(CreateDailyTransactionCommand.fromJS(this.dailyTransactionSvc.dailyTransactionForm.value))
      .subscribe(result => {
        console.log(result);
      },
      error => {
        console.log(error);
      });

   }

  getBondInfo(bondUserId: number): void {
    console.log('getBondInfo');

    this.bondsClient.bondByCustomerIdAndBondCustomerIdQuery(this.dailyTransactionSvc.customerId, 
      bondUserId, this.dailyTransactionSvc.financeYear)
      .subscribe(
        result => {
          if (result) {
            this.dailyTransactionSvc.dailyTransactionForm.patchValue({
              bondId: result.bondId,
              bondName: result.bondNameAr,
              dailyTransactionBondSNo: result.bondMaxSNo
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

  getDetailAccountInfo(detailAccountIdByCustomer, index){
    console.log('getDetailAccountInfo');

    this.detailAccountsClient.detailAccount(this.dailyTransactionSvc.customerId, detailAccountIdByCustomer)
    .subscribe(
      result => {
        if(result){
          console.log(result);
          this.dailyTransactionSvc.dailyTransactionDetailsList.at(index).patchValue({
            detailAccountNameAr: result.detailAccountNameAr,
            detailAccountNameEn: result.detailAccountNameEn,
            generalLedgerId: result.generalLeadgerId,
            mainAccountId: result.mainAccountId,
            totalAccountId: result.totalAccountId,
            detailAccountId: result.id,
            dailyTransactionYear: this.dailyTransactionSvc.financeYear,
          });

          this.dailyTransactionDebitAmount.nativeElement.focus();
          this.dailyTransactionDebitAmount.nativeElement.select();
        } 
      },
      error => {
        console.log(error);        
      });
  }
  // @ViewChildren("input") inputs: QueryList<any>
  
  // onKeyDown(event, index){
  //   console.log('onKeyDown');
    
  //   if(event.key =="Enter"){
  //     if(index + 1 < this.inputs.toArray().length){
  //       this.inputs.toArray()[index+3].nativeElement.focus();
  //     }else {
  //       this.inputs.toArray()[0].nativeElement.focus();
  //     }
  //   }
  // }

  onClose(){
    console.log('close');
    this.dailyTransactionSvc.initalizeDailyTransactionForm();
    this.bondIdFiled.nativeElement.focus();
  }

}
