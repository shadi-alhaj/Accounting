import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TodoComponent } from './todo/todo.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CustomerModule } from './customer/customer.module';
import { MaterialModule } from './shared/material/material.module';
import { SharedModule } from './shared/shared/shared.module';
import { FinanceYearModule } from './finance-year/finance-year.module';
import { SelectedDashboardModule } from './selected-dashboard/selected-dashboard.module';
import { AppRoutingModule } from './app-routing.module';
import { BondModule } from './bond/bond.module';
import { AccountTreeModule } from './account-tree/account-tree.module';
import { DailyTransactionModule } from './daily-transaction/daily-transaction.module';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TodoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    CustomerModule,
    MaterialModule,
    SharedModule,
    FinanceYearModule,
    SelectedDashboardModule,
    AppRoutingModule,
    BondModule,
    AccountTreeModule,
    DailyTransactionModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
