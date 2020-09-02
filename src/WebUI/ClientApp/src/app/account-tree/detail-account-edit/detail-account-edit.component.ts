import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AccountTreeService } from '../account-tree.service';
import { TotalAccountsClient, DetailAccountsClient } from 'src/app/accounting-api';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-detail-account-edit',
  templateUrl: './detail-account-edit.component.html',
  styleUrls: ['./detail-account-edit.component.css']
})
export class DetailAccountEditComponent implements OnInit {

  errorMessages = {};
  @ViewChild('mainAccountNameAr', { static: false }) nameFiled: ElementRef;

  constructor(public accountTreeSvc: AccountTreeService,
              private detailAccountsClient: DetailAccountsClient,
              private totalAccountsClient: TotalAccountsClient,
              private dialogRef: MatDialogRef<DetailAccountEditComponent>,
              private dialog: MatDialog) { }

  ngOnInit() {
  }

  getMainAndTotalAccount(){
    
  }

  onClose(){
    this.dialogRef.close();
  }

  onSubmit(){
    if(this.accountTreeSvc.selectedDetailAccount === null){
        this.addNewDetailAccount();
    }else{
      this.updateDetailAccount();
    }
  }
  updateDetailAccount() {
    throw new Error("Method not implemented.");
  }
  addNewDetailAccount() {
    throw new Error("Method not implemented.");
  }

}
