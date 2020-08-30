import { MaterialModule } from './../material/material.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { CustomerLovComponent } from '../lov/customer-lov/customer-lov.component';

import { SelectDropDownModule } from 'ngx-select-dropdown';
import { SideBarMenuComponent } from '../side-bar-menu/side-bar-menu.component';
import { GeneralLeadgerLovComponent } from '../lov/general-leadger-lov/general-leadger-lov.component';
import { GeneralLedgerListComponent } from '../general-ledger-list/general-ledger-list.component'

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    CustomerLovComponent,
    SideBarMenuComponent,
    GeneralLeadgerLovComponent,
    GeneralLedgerListComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    RouterModule,
    SelectDropDownModule
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    RouterModule,
    CustomerLovComponent,
    SideBarMenuComponent,
    GeneralLedgerListComponent
  ],
  entryComponents: [
    ConfirmationDialogComponent,
    GeneralLedgerListComponent
  ]
})
export class SharedModule { }
