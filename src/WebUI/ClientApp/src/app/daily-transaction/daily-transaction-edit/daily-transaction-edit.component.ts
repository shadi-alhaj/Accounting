import { DailyTransactionService } from './../daily-transaction.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-daily-transaction-edit',
  templateUrl: './daily-transaction-edit.component.html',
  styleUrls: ['./daily-transaction-edit.component.css']
})
export class DailyTransactionEditComponent implements OnInit {
  
  pageTitle = 'Daily Transaction';

  constructor(public dailyTransactionSvc: DailyTransactionService) { }

  ngOnInit() {
  }

  onSubmit(){}

}
