import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinanceYearListComponent } from './finance-year-list.component';

describe('FinanceYearListComponent', () => {
  let component: FinanceYearListComponent;
  let fixture: ComponentFixture<FinanceYearListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinanceYearListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinanceYearListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
