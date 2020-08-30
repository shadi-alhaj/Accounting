import { ConfirmationService } from './../../shared/services/confirmation.service';
import { Router } from '@angular/router';

import { CustomerService } from './../customer.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { CustomerVm, CustomerDto } from 'src/app/accounting-api';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator } from '@angular/material/paginator';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {
  pageTitle = 'Customer List';
  
  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;
  
  customerList: CustomerVm;
  displayedColumns = ['customerId', 'customerName', 'phoneNo', 'mobileNo', 'address','actions'];
  dataSource: MatTableDataSource<CustomerVm>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  
  constructor(private customerSvc: CustomerService,
              private router: Router,
              private confirmationSvc: ConfirmationService,
              private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.customerList = new CustomerVm();
    this.getCustomerList();    
  }
  
  getCustomerList(){
    this.customerSvc.getCustomers().subscribe(
      result => {
        this.customerList = result;
        this.dataSource = new MatTableDataSource(this.customerList.lists);
        setTimeout(() => this.dataSource.paginator = this.paginator);
      },
      error => {

      });
  }

  onDelete(id){
    this.confirmationSvc
        .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Customer')
        .afterClosed()
        .subscribe(
          result => {
            if(result){
              this.customerSvc.deleteCustomer(id).subscribe(
                result => {
                  this.snackBar.open('Record has been deleted successfully!', 'Delete', {
                    duration: 2000,
                    verticalPosition: 'top',
                    horizontalPosition: 'center'
                  });
                  this.getCustomerList();
                },
                error => {
          
                });
            }
          }
        )
  }

  onEdit(customer: CustomerDto){
    this.customerSvc.selectedCustomer = customer.id;
    this.customerSvc.customerForm.patchValue(customer);
    this.router.navigate(['./customer-edit']);
  }

}
