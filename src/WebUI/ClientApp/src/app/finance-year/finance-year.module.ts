import { SharedModule } from './../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FinanceYearListComponent } from './finance-year-list/finance-year-list.component';
import { FinanceYearEditComponent } from './finance-year-edit/finance-year-edit.component';

@NgModule({
  declarations: [FinanceYearListComponent, FinanceYearEditComponent],
  imports: [
    SharedModule
  ],
  entryComponents: [
    FinanceYearEditComponent
  ]
})
export class FinanceYearModule { }
