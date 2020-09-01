import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountTreeService {

  customerId = null;
  selectedGl = null;
  selectedMainAccount = null;
  selectedTotalAccount = null;
  selectedDetailAccount = null;

  glForm: FormGroup;
  mainAccountForm: FormGroup;
  totalAccountForm: FormGroup;
  detailAccountForm: FormGroup;

  constructor(private fb: FormBuilder) { 
    const customer = JSON.parse(localStorage.getItem('customer'));
    this.customerId = customer.cusId;
    this.initalizeGlForm();
    this.intializeMainAccountForm();
    this.initalizeTotalAccountForm();
  }

  initalizeGlForm(){
    this.glForm = this.fb.group({
      id: '',
      glIdByCustomer: [null, [Validators.required]],
      glNameAr: ['',[Validators.required]],
      glNameEn: [''],
      customerId: ['', [Validators.required]]
    });
  }

  intializeMainAccountForm(){    
    this.mainAccountForm = this.fb.group({
      id: '',
      mainAccountIdByCustomer: [null, [Validators.required]],
      mainAccountNameAr: ['', [Validators.required]],
      mainAccountNameEn: [''],
      customerId: ['', [Validators.required]],
      generalLeadgerId: ['', [Validators.required]],
      glIdByCustomer:[null, [Validators.required]],
      glNameAr:['', [Validators.required]]
    });
  }

  initalizeTotalAccountForm(){
    this.totalAccountForm = this.fb.group({
      id: '',
      totalAccountIdByCustomer: [null, [Validators.required]],
      totalAccountNameAr: ['', [Validators.required]],
      totalAccountNameEn: [''],
      isClose: false,
      customerId: ['', [Validators.required]],
      generalLeadgerId: ['', [Validators.required]],
      mainAccountId: [''],
      mainAccountIdByCustomer:[null, [Validators.required]],
      mainAccountNameAr:['', [Validators.required]]
    });
  }
}

