import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyTransactionEditComponent } from './daily-transaction-edit.component';

describe('DailyTransactionEditComponent', () => {
  let component: DailyTransactionEditComponent;
  let fixture: ComponentFixture<DailyTransactionEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyTransactionEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyTransactionEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
