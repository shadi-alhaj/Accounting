import { FormControl, FormGroup, FormArray } from '@angular/forms';
import {
  BondsClient, DetailAccountsClient,
  DailyTransactionsClient, CreateDailyTransactionCommand, DailyTransactionDetailsDto
} from 'src/app/accounting-api';
import { DailyTransactionService } from './../daily-transaction.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { faAngleDoubleLeft, faAngleDoubleRight, faAngleLeft, faAngleRight, faArrowCircleLeft, faArrowLeft, faArrowRight, faFile } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-daily-transaction-edit',
  templateUrl: './daily-transaction-edit.component.html',
  styleUrls: ['./daily-transaction-edit.component.css']
})
export class DailyTransactionEditComponent implements OnInit {

  pageTitle = 'Daily Transaction';

  privousRecord = faAngleLeft;
  nextRecord = faAngleRight;
  firstRecord = faAngleDoubleLeft;
  lastRecord = faAngleDoubleRight;
  newRecord = faFile;


  @ViewChild('bondDate', { static: false }) bondDateFiled: ElementRef;
  @ViewChild('bondUserId', { static: false }) bondIdFiled: ElementRef;
  @ViewChild('dailyTransactionDebitAmount', { static: false }) dailyTransactionDebitAmount: ElementRef;
  errorMessages = {
    DailyTransactionBondSNo: '', CustomerId: '', BondId: '', DailyTransactionDate: '',
    DailyTransactionMonth: '', DailyTransactionDetailsList: ''
  };

  dailyTransactionDetailsList: DailyTransactionDetailsDto[] = [];
  dailyTransactionDetails: DailyTransactionDetailsDto;

  constructor(private dailyTransactionsClient: DailyTransactionsClient,
    public dailyTransactionSvc: DailyTransactionService,
    private bondsClient: BondsClient,
    private detailAccountsClient: DetailAccountsClient) { }

  ngOnInit() {
    this.dailyTransactionDetails = new DailyTransactionDetailsDto();
    this.dailyTransactionSvc.dailyTransactionForm.patchValue({
      customerId: this.dailyTransactionSvc.customerId,
      dailyTransactionYear: this.dailyTransactionSvc.financeYear
    });
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
          this.errorMessages = JSON.parse(error.response);
        });

  }

  getBondInfo(bondUserId: number): void {
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
          this.errorMessages = JSON.parse(error.response);
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            bondId: '',
            bondName: '',
            bondSno: null
          });
        });
  }

  getDetailAccountInfo(detailAccountIdByCustomer, index) {
    console.log('getDetailAccountInfo');

    this.detailAccountsClient.detailAccount(this.dailyTransactionSvc.customerId, detailAccountIdByCustomer)
      .subscribe(
        result => {
          if (result) {
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

  onClose() {
    console.log('close');
    this.dailyTransactionSvc.initalizeDailyTransactionForm();
    this.bondIdFiled.nativeElement.focus();
  }

  getDailyTransactionBySno() {
    const bondSNo = this.dailyTransactionSvc.dailyTransactionForm.get('dailyTransactionBondSNo').value;
    const formArray = new FormArray([]);


    this.dailyTransactionsClient.dailyTransactionBySNoAndFinanceYearQuery(this.dailyTransactionSvc.customerId,
      this.dailyTransactionSvc.financeYear, bondSNo).subscribe(result => {
        console.log(result);
        result.lists.forEach(element => {
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            bondId: element.bondId,
            bondUserId: element.bondUserId,
            bondName: element.bondName,
            customerId: element.customerId,
            dailyTransactionBondSNo: element.dailyTransactionBondSNo,
            dailyTransactionDate:    element.dailyTransactionDate,
            dailyTransactionMonth:   element.dailyTransactionMonth,
            dailyTransactionYear:    element.dailyTransactionYear,
            //dailyTransactionDetailsList: formArray.push(this.dailyTransactionSvc.pushValue(element))
          });
          this.dailyTransactionSvc.dailyTransactionDetailsList.push(this.dailyTransactionSvc.pushValue(element));

          console.log(this.dailyTransactionSvc.dailyTransactionForm);
          
        });
      },
        error => {
          console.log(error);

        });
  }

  onGetFirstRecord(){
    this.onNewRecord();
    this.dailyTransactionsClient.firstDailyTransactionRecord(this.dailyTransactionSvc.customerId,
      this.dailyTransactionSvc.financeYear).subscribe(result => {
        console.log(result);
        result.lists.forEach(element => {
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            bondId: element.bondId,
            bondUserId: element.bondUserId,
            bondName: element.bondName,
            customerId: element.customerId,
            dailyTransactionBondSNo: element.dailyTransactionBondSNo,
            dailyTransactionDate:    element.dailyTransactionDate,
            dailyTransactionMonth:   element.dailyTransactionMonth,
            dailyTransactionYear:    element.dailyTransactionYear
          });
          this.dailyTransactionSvc.dailyTransactionDetailsList.push(this.dailyTransactionSvc.pushValue(element));
        });
      },
        error => {
          console.log(error);

        });
  }

  onGetLastRecord(){
    this.onNewRecord();
    this.dailyTransactionsClient.lastDailyTransactionRecord(this.dailyTransactionSvc.customerId,
      this.dailyTransactionSvc.financeYear).subscribe(result => {
        console.log(result);
        result.lists.forEach(element => {
          this.dailyTransactionSvc.dailyTransactionForm.patchValue({
            bondId: element.bondId,
            bondUserId: element.bondUserId,
            bondName: element.bondName,
            customerId: element.customerId,
            dailyTransactionBondSNo: element.dailyTransactionBondSNo,
            dailyTransactionDate:    element.dailyTransactionDate,
            dailyTransactionMonth:   element.dailyTransactionMonth,
            dailyTransactionYear:    element.dailyTransactionYear
          });
          this.dailyTransactionSvc.dailyTransactionDetailsList.push(this.dailyTransactionSvc.pushValue(element));
        });
      },
        error => {
          console.log(error);

        });
  }
  onNewRecord(){
    this.dailyTransactionSvc.initalizeDailyTransactionForm();
    this.ngOnInit();
  }

}
