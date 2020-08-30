import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-dashboard',
  templateUrl: './home-dashboard.component.html',
  styleUrls: ['./home-dashboard.component.css']
})
export class HomeDashboardComponent implements OnInit {
  customerName: string;
  financeYear: number;
  constructor() { }

  ngOnInit() {
    const customer = JSON.parse( localStorage.getItem('customer'));
    this.customerName = customer.customerNameAr;
    this.financeYear = customer.year;
  }

}
