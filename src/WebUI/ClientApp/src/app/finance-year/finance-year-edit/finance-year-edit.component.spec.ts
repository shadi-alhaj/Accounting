import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinanceYearEditComponent } from './finance-year-edit.component';

describe('FinanceYearEditComponent', () => {
  let component: FinanceYearEditComponent;
  let fixture: ComponentFixture<FinanceYearEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinanceYearEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinanceYearEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
