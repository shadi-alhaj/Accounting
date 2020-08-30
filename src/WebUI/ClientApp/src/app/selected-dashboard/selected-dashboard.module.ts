import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared/shared.module';
import { HomeDashboardComponent } from './home-dashboard/home-dashboard.component';
@NgModule({
  declarations: [HomeDashboardComponent],
  imports: [
    SharedModule
  ]
})
export class SelectedDashboardModule { }
