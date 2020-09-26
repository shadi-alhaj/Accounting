import { FormGroup, FormBuilder, FormArray, Validators, FormControl } from '@angular/forms';
import { Injectable } from '@angular/core';
import { DailyTransactionDetailsDto, DailyTransactionDto } from 'src/app/accounting-api';

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
      bondUserId: [null, [Validators.required]],
      bondName: '',
      customerId: '',
      dailyTransactionBondSNo: [null, [Validators.required]],
      dailyTransactionDate: [Date, [Validators.required]],
      dailyTransactionMonth: [null, [Validators.required]],
      dailyTransactionYear: [null, [Validators.required]],
      dailyTransactionDetailsList: this.fb.array([]),
      sumDebit: 0.000,
      sumCredit: 0.000,
      difference: 0.000,
    });

    this.dailyTransactionForm.get('dailyTransactionDate')
      .valueChanges.subscribe(value => {
        if (Date.parse(value)) {
          this.dailyTransactionForm.get('dailyTransactionMonth').patchValue(
            value.getMonth() + 1
          )
        } 
      });

    this.dailyTransactionForm.get('dailyTransactionDetailsList')
      .valueChanges.subscribe(newVal => {
        this.dailyTransactionForm.get('sumDebit').patchValue(
          newVal.reduce((acc, curr) => {
            return acc + (+curr.dailyTransactionDebitAmount);
          }, 0)
        )

        this.dailyTransactionForm.get('sumCredit').patchValue(
          newVal.reduce((acc, curr) => {
            return acc + (+curr.dailyTransactionCreditAmount);
          }, 0)
        )

        this.dailyTransactionForm.get('difference').patchValue(
          +this.dailyTransactionForm.get('sumDebit').value - +this.dailyTransactionForm.get('sumCredit').value
        )

      });
  }

  get dailyTransactionDetailsList(): FormArray {
    return <FormArray>this.dailyTransactionForm.get('dailyTransactionDetailsList');
  }

  buildDailyTrnsactionDetails(): FormGroup {
    return this.fb.group({
      detailAccountIdByCustomer: [null, [Validators.required]],
      detailAccountId: ['', [Validators.required]],
      detailAccountNameAr: '',
      detailAccountNameEn: '',
      dailyTransactionDebitAmount: [0, [Validators.required]],
      dailyTransactionCreditAmount: [0, [Validators.required]],
      dailyTransactionDescription: '',
      totalAccountId: '',
      mainAccountId: '',
      generalLedgerId: ''
    });
  }

  addDailyTransactionDetails() {
    this.dailyTransactionDetailsList.push(this.buildDailyTrnsactionDetails());
  }

  removeDailyTransactionDetails(index) {
    this.dailyTransactionDetailsList.removeAt(index);
  }

  pushValue(dto: DailyTransactionDto){
    return  this.fb.group({
      detailAccountIdByCustomer: dto.detailAccountIdByCustomer,
      detailAccountId: dto.detailAccountId,
      detailAccountNameAr: dto.detailAccountNameAr,
      detailAccountNameEn: dto.detailAccountNameEn,
      dailyTransactionDebitAmount:  dto.dailyTransactionDebitAmount,
      dailyTransactionCreditAmount: dto.dailyTransactionCreditAmount,
      dailyTransactionDescription: dto.dailyTransactionDescription,
      totalAccountId:  dto.totalAccountId,
      mainAccountId:   dto.mainAccountId,
      generalLedgerId: dto.generalLedgerId
    });
  }
}
