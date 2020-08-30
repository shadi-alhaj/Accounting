import { Injectable } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class FinanceYearService {
  selectedFinanceYear = null;
  financeYearForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.intializeFinanceYearForm();
   }

  intializeFinanceYearForm(){
    this.financeYearForm = this.fb.group({
      id: '',
      customerId: ['', [Validators.required]],
      customerNameAr: [''],
      year: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(4)]]
    });
  }
}
