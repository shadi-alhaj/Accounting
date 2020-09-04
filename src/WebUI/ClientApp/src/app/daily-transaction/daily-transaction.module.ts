import { SharedModule } from './../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { DailyTransactionEditComponent } from './daily-transaction-edit/daily-transaction-edit.component';

@NgModule({
  declarations: [DailyTransactionEditComponent],
  imports: [
    SharedModule
  ]
})
export class DailyTransactionModule { }
