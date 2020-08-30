import { MatDialogRef } from '@angular/material/dialog';
import { FinanceYearService } from './../finance-year.service';
import { Component, OnInit } from '@angular/core';
import { FinanceYearsClient, CreateFinanceYearCommand, UpdateFinanceYearCommand } from 'src/app/accounting-api';

@Component({
  selector: 'app-finance-year-edit',
  templateUrl: './finance-year-edit.component.html',
  styleUrls: ['./finance-year-edit.component.css']
})
export class FinanceYearEditComponent implements OnInit {

   errorMessages = {CustomerId: '', Year: ''};
  constructor(public finYearSvc: FinanceYearService, 
              private dialogRef: MatDialogRef<FinanceYearEditComponent>,
              private finYearsClient: FinanceYearsClient) { }

  ngOnInit() {
  }

  onClose(){
    this.dialogRef.close();
  }

  getCustomerId(customerId){
    this.finYearSvc.financeYearForm.patchValue({
      customerId: customerId
    });
  }

  onSubmit(){
    if(this.finYearSvc.selectedFinanceYear === null){
      this.addNewFinanceYear();      
    }else{
      this.updateFinanceYear();
    }
  }
  addNewFinanceYear() {
    this.finYearsClient.createFinanceYear(CreateFinanceYearCommand.fromJS(this.finYearSvc.financeYearForm.value))
    .subscribe(
      result =>{
        this.finYearSvc.intializeFinanceYearForm();
        this.onClose();
      }, 
      error => {
        this.errorMessages = JSON.parse(error.response);
      });
  }
  updateFinanceYear() {
    this.finYearsClient.updateFinanceYear(this.finYearSvc.financeYearForm.get('id').value,
                                          UpdateFinanceYearCommand.fromJS(this.finYearSvc.financeYearForm.value))
    .subscribe(
      result =>{
        this.finYearSvc.intializeFinanceYearForm();
        this.onClose();
      }, 
      error => {
        this.errorMessages = JSON.parse(error.response);
      });
  }

}
