import { SharedModule } from './../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { AccountTreeComponent } from './account-tree/account-tree.component';
import { MainAccountComponent } from './main-account/main-account.component';
import { TotalAccountComponent } from './total-account/total-account.component';
import { DetailAccountComponent } from './detail-account/detail-account.component';
import { GeneralLedgerAccountComponent } from './general-ledger-account/general-ledger-account.component';
import { GeneralLedgerAccountEditComponent } from './general-ledger-account-edit/general-ledger-account-edit.component';
import { DetailAccountEditComponent } from './detail-account-edit/detail-account-edit.component';
import { TotalAccountEditComponent } from './total-account-edit/total-account-edit.component';
import { MainAccountEditComponent } from './main-account-edit/main-account-edit.component';

@NgModule({
  declarations: [
    AccountTreeComponent,
    MainAccountComponent,
    TotalAccountComponent,
    DetailAccountComponent,
    GeneralLedgerAccountComponent,
    GeneralLedgerAccountEditComponent,
    DetailAccountEditComponent,
    TotalAccountEditComponent,
    MainAccountEditComponent
  ],
  imports: [
    SharedModule
  ],
  entryComponents: [
    GeneralLedgerAccountEditComponent,
    MainAccountEditComponent
  ]
})
export class AccountTreeModule { }
