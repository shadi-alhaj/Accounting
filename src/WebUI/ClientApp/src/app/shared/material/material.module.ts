import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTableModule} from '@angular/material/table';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import {MatTabsModule} from '@angular/material/tabs';
import {MatCheckboxModule} from '@angular/material/checkbox';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatTableModule,
    MatSnackBarModule,
    MatDialogModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatIconModule,
    FontAwesomeModule,
    MatTabsModule,
    MatCheckboxModule
  ],
  exports:[
    MatTableModule,
    MatSnackBarModule,
    MatDialogModule,
    MatPaginatorModule,
    MatToolbarModule,
    MatIconModule,
    FontAwesomeModule,
    MatTabsModule,
    MatCheckboxModule
  ]
})
export class MaterialModule { }
