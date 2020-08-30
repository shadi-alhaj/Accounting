import { SharedModule } from './../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { BondListComponent } from './bond-list/bond-list.component';
import { BondEditComponent } from './bond-edit/bond-edit.component';

@NgModule({
  declarations: [BondListComponent, BondEditComponent],
  imports: [
    SharedModule
  ],
  entryComponents: [BondEditComponent]
})
export class BondModule { }
