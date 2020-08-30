import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerLovComponent } from './customer-lov.component';

describe('CustomerLovComponent', () => {
  let component: CustomerLovComponent;
  let fixture: ComponentFixture<CustomerLovComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CustomerLovComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerLovComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
