import { FormGroup, FormBuilder } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BondService {

  selectedBond = null;
  bondForm: FormGroup;

  constructor(private fb: FormBuilder) { 
    this.intializeBondForm();
  }

  intializeBondForm(){
    this.bondForm = this.fb.group({
      id: '',
      bondUserId: [null],
      intialSNo :[1],
      bondNameAr:[''],
      bondNameEn:[''],
      customerId:['']
    });
  }
}
