import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { CustomersClient, CustomerLovVm } from 'src/app/accounting-api';


@Component({
  selector: 'app-customer-lov',
  templateUrl: './customer-lov.component.html',
  styleUrls: ['./customer-lov.component.css']
})
export class CustomerLovComponent implements OnInit {
  customerLovList: CustomerLovVm;
  @Output() selectedCustomer = new EventEmitter();
 
  config = {
    displayKey: 'customerNameAr',
    search: true,
    clearOnSelection: true,
    noResultsFound: 'No results found!',
    disabled: true
  };

  constructor(private customersClient: CustomersClient) { }

  ngOnInit() {
    this.customerLovList  = new CustomerLovVm();
    this.getCustomerLov();
  }

  getCustomerLov(){
    this.customersClient.customersLov().subscribe(
      result => {
        this.customerLovList = result;
      },
      error => {
        console.log(error);        
      });
  }

  selectionChange(event){
    if(event !== null){
      const customer = event.value;
      this.selectedCustomer.emit(customer.id);
    }
  }

}
