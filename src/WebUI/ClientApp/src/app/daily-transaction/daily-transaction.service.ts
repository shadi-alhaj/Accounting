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
      sumDebit: null,
      sumCredit: null,
      difference: null,
    });
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
      dailyTransactionDebitAmount: null,
      dailyTransactionCreditAmount: null,
      dailyTransactionDescription: '',
      totalAccountId:'',
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
