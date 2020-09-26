import { DailyTransactionEditComponent } from './daily-transaction/daily-transaction-edit/daily-transaction-edit.component';
import { AccountTreeComponent } from './account-tree/account-tree/account-tree.component';
import { BondListComponent } from './bond/bond-list/bond-list.component';
import { HomeDashboardComponent } from './selected-dashboard/home-dashboard/home-dashboard.component';
import { FinanceYearListComponent } from './finance-year/finance-year-list/finance-year-list.component';
import { AuthorizeGuard } from './../api-authorization/authorize.guard';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { TodoComponent } from './todo/todo.component';
import { CustomerListComponent } from './customer/customer-list/customer-list.component';
import { CustomerEditComponent } from './customer/customer-edit/customer-edit.component';

const routes: Routes = [
  { path: '', redirectTo: 'finance-year-list', pathMatch: 'full' },
  { path: 'todo', component: TodoComponent, canActivate: [AuthorizeGuard] },
  { path: 'customer-list', component: CustomerListComponent, canActivate: [AuthorizeGuard] },
  { path: 'customer-edit', component: CustomerEditComponent, canActivate: [AuthorizeGuard] },
  { path: 'finance-year-list', component: FinanceYearListComponent, canActivate: [AuthorizeGuard] },
  {
    path: 'selected-customer', component: HomeDashboardComponent, canActivate: [AuthorizeGuard],
    children: [
      {path: 'bond-list', component: BondListComponent, canActivate: [AuthorizeGuard]},
      {path: 'account-tree', component: AccountTreeComponent, canActivate: [AuthorizeGuard]},
      {path: 'daily-transaction', component: DailyTransactionEditComponent, canActivate: [AuthorizeGuard]},
    ]
  }];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
