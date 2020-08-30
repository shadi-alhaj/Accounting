import { Router } from '@angular/router';
import { FinanceYearService } from './../finance-year.service';
import { MatPaginator } from '@angular/material/paginator';
import { FinanceYearsClient, FinanceYearVm } from 'src/app/accounting-api';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { FinanceYearEditComponent } from '../finance-year-edit/finance-year-edit.component';
import { MatTableDataSource } from '@angular/material/table';
import { ConfirmationService } from 'src/app/shared/services/confirmation.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { faPlus, faEdit, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-finance-year-list',
  templateUrl: './finance-year-list.component.html',
  styleUrls: ['./finance-year-list.component.css']
})
export class FinanceYearListComponent implements OnInit {
  pageTitle = 'Customer Fiance Year';
  faPlus = faPlus;
  faEdit = faEdit;
  faDelete = faTrash;
  
  displayedColumns = ['rowId','customerId', 'customerName', 'financeYear', 'actions'];
  dataSource: MatTableDataSource<FinanceYearVm>;
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  
  constructor(private dialog: MatDialog,
              private finYearsClient: FinanceYearsClient,
              private finYearSvc: FinanceYearService,
              private confirmationSvc: ConfirmationService,
              private snackBar: MatSnackBar,
              private router: Router) { }

  ngOnInit() {
    this.getFinanceYearList();
  }

  getFinanceYearList(){
    this.finYearsClient.financeYears()
      .subscribe(
        result => {
          this.dataSource = new MatTableDataSource(result.lists);
          setTimeout(() => this.dataSource.paginator = this.paginator);
        },
        error => {

        }
      )
  }

  openFinanceYearDialog(){
    this.dialog.open(FinanceYearEditComponent, {
      width: '50%'
    })
    .afterClosed()
    .subscribe(
      () => this.getFinanceYearList()
    );
  }

  onCreate(){
    this.finYearSvc.selectedFinanceYear = null;
    this.finYearSvc.intializeFinanceYearForm();
    this.openFinanceYearDialog();
  }

  onEdit(financeYear){
   this.finYearSvc.selectedFinanceYear = financeYear.id;
    this.finYearSvc.financeYearForm.patchValue({
    id: financeYear.id,
    customerId: financeYear.cusId,
    customerNameAr: financeYear.customerNameAr,
    year: financeYear.year
   });
   this.openFinanceYearDialog();
  }

  onDelete(id){
    this.confirmationSvc
        .openConfirmationDialog('Are you sure want to delete this record?', 'Delete Finance Year')
        .afterClosed()
        .subscribe(
          result => {
            if(result){
              this.finYearsClient.deleteFinanceYear(id).subscribe(
                result => {
                  this.snackBar.open('Record has been deleted successfully!', 'Delete', {
                    duration: 2000,
                    verticalPosition: 'top',
                    horizontalPosition: 'center'
                  });
                  this.getFinanceYearList();
                },
                error => {
                  console.log(error);
                });
            }
          });
  }

  onRowClick(row){
    localStorage.setItem('customer', JSON.stringify(row));
    this.router.navigate(['/selected-customer']);    
  }

}
