import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DailyTransactionService {
  dailyTransactionForm: FormGroup;
  customerId = null;
  financeYear = null;

  constructor(private fb: FormBuilder) {
    const customer = JSON.parse(localStorage.getItem('customer'));
    this.customerId = customer.cusId;
    this.financeYear = customer.year;
    this.initalizeDailyTransactionForm();
   }

  initalizeDailyTransactionForm() {
    this.dailyTransactionForm = this.fb.group({
      bondId: '',
      bondUserId: null,
      bondName: '',
      dailyTransactionBondSNo: null,
      dailyTransactionDate: Date,
      dailyTransactionMonth: null,
      dailyTransactionYear: null,
      dailyTransactionDetails: this.fb.array([this.buildDailyTrnsactionDetails()]),
      sumDebit: 0.000,
      sumCredit: 0.000,
      difference: 0.000,
    });

    // this.dailyTransactionForm.get('dailyTransactionDetails')['controls'][4]
    // .valueChanges.subscribe((newVal) => {

    //     this.dailyTransactionForm.get('sumDebit').patchValue(
    //       newVal.reduce((acc, curr) => {
    //         return acc + (+curr.value);
    //       }, 0)
    //     )

    // });

    // this.dailyTransactionDetails.get('dailyTransactionDebitAmount')['control'][].valueChanges.subscribe((newVal) => {
    //   this.dailyTransactionForm.get('sumDebit').patchValue(
    //     newVal.reduce((acc, curr) => {
    //       return acc + (+curr.value);
    //     }, 0)
    //   )
    // });
  }

  get dailyTransactionDetails() : FormArray{
    return <FormArray> this.dailyTransactionForm.get('dailyTransactionDetails');
  }
  
  buildDailyTrnsactionDetails(): FormGroup{
    return this.fb.group({
      detailAccountIdByCustomer: null,
      detailAccountId: '',
      detailAccountNameAr: '',
      detailAccountNameEn: '',
      dailyTransactionDebitAmount: 0.000,
      dailyTransactionCreditAmount: 0.000,
      dailyTransactionDescription: '',
      totalAccountId: '',
      mainAccountId: '',
      generalLedgerId: ''
    });
  }

  addDailyTransactionDetails(){
    this.dailyTransactionDetails.push(this.buildDailyTrnsactionDetails());
  }

  removeDailyTransactionDetails(index){
    this.dailyTransactionDetails.removeAt(index);
  }
}
