import { GeneralLedgersClient, GeneralLedgerLovVm } from 'src/app/accounting-api';
import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';

@Component({
  selector: 'app-general-leadger-lov',
  templateUrl: './general-leadger-lov.component.html',
  styleUrls: ['./general-leadger-lov.component.css']
})
export class GeneralLeadgerLovComponent implements OnInit {
  generalLeadgerLovList: GeneralLedgerLovVm;
  @Output() selectedGeneralLeadger = new EventEmitter();
  @Input() customerId;
  
  config = {
    displayKey: 'customerNameAr',
    search: true,
    clearOnSelection: true,
    noResultsFound: 'No results found!',
    disabled: true
  };

  constructor(private glsClient: GeneralLedgersClient) { }

  ngOnInit() {
    this.generalLeadgerLovList  = new GeneralLedgerLovVm();
    this.getGeneralLeadgerLov();
  }

  getGeneralLeadgerLov(){
    this.glsClient.generalLedgersLov(this.customerId).subscribe(
      result => {
        this.generalLeadgerLovList = result;
      },
      error => {
        console.log(error);        
      });
  }

  selectionChange(event){
    if(event !== null){
      const generalLeadger = event.value;
      this.selectedGeneralLeadger.emit(generalLeadger.id);
    }
  }

}
