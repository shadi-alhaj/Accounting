import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DailyTransactionService {
  dailyTransactionForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.initalizeDailyTransactionForm();
   }

  initalizeDailyTransactionForm() {
    this.dailyTransactionForm = this.fb.group({
      bondUserId: null,
      bondName: '',
      bondSno: null,
      bondDate: Date,
      bondMonth: null,
      bondyear: null,
      bondDetails: this.fb.array([this.buildBondDetails()]),
      sumDebit: null,
      sumCredit: null,
      difference: null,
    });
  }

  get bondDetails() : FormArray{
    return <FormArray> this.dailyTransactionForm.get('bondDetails');
  }

  buildBondDetails(): FormGroup{
    return this.fb.group({
      detailAccountIdByCustomer: null,
      detailAccountNameAr: '',
      detailAccountNameEn: '',
      debitAmount: null,
      creditAmount: null,
      description: ''
    });
  }

  addBondDetails(){
    this.bondDetails.push(this.buildBondDetails());
  }

  removeBondDetails(index){
    this.bondDetails.removeAt(index);
  }
}
