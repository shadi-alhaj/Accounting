import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { CustomersClient, CustomerVm } from '../accounting-api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  customerForm: FormGroup;
  selectedCustomer = null;
  constructor(private customersClient: CustomersClient,
              private fb: FormBuilder) {
    this.initalizeCustomerForm();
  }

  initalizeCustomerForm() {
    this.customerForm = this.fb.group({
      id: '',
      customerId: null,
      customerNameAr: ['', [Validators.required, Validators.maxLength(250)]],
      customerNameEn: ['', [Validators.maxLength(250)]],
      taxNo: ['', [Validators.maxLength(20)]],
      faxNo: ['', [Validators.maxLength(20)]],
      phoneNo: ['', [Validators.maxLength(20)]],
      mobileNo1: ['', [Validators.maxLength(14)]],
      mobileNo2: ['', [Validators.maxLength(14)]],
      country: ['Jordan', [Validators.max(100)]],
      city: ['Amman', [Validators.maxLength(100)]],
      address: ['', [Validators.maxLength(250)]],
      email: ['', [Validators.email, Validators.maxLength(100)]]
    });
  }
  
  getCustomers(): Observable<CustomerVm> {
    return this.customersClient.customers();
  }

  deleteCustomer(id){
    return this.customersClient.deleteCustomer(id);
  }
}
