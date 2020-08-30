import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';

@Injectable({
  providedIn: 'root'
})
export class ConfirmationService {

  constructor(private dialog: MatDialog) { }

  openConfirmationDialog(msg: string, title?: string ){
    return this.dialog.open(ConfirmationDialogComponent,{
      width: '450px',
      data:{
        title: title? title: 'Delete',
        message: msg
      }
    });
  }
}
