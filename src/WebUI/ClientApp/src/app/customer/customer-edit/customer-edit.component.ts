import { Router } from '@angular/router';
import { CustomerService } from './../customer.service';
import { Component, OnInit } from '@angular/core';
import { CustomersClient, CreateCustomerCommand, UpdateCustomerCommand } from 'src/app/accounting-api';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.css']
})
export class CustomerEditComponent implements OnInit {

  constructor(public customerSvc: CustomerService,
    private router: Router,
    private customersClient: CustomersClient,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
  }

  onClose() {
    this.customerSvc.initalizeCustomerForm();
    this.router.navigate(['/customer-list']);
  }

  onSubmit() {
    if (this.customerSvc.selectedCustomer === null) {
      this.addNewCustomer();
    } else {
      this.updateCustomer();
    }
  }
  updateCustomer() {
    this.customersClient
     .updateCustomer(this.customerSvc.selectedCustomer, UpdateCustomerCommand.fromJS(this.customerSvc.customerForm.value))
     .subscribe(
       result => {
        this.snackBar.open('Record has been updated successfully!', 'Updated', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center'
        });
       },
       error => {

       });
  }
  addNewCustomer() {
    this.customersClient.createCustomer(CreateCustomerCommand.fromJS(this.customerSvc.customerForm.value)).subscribe(
      result => {
        this.snackBar.open('Record has been added successfully!', 'Added', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center'
        });
        this.customerSvc.initalizeCustomerForm();
      },
      error => {

      });
  }
}
