import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralLeadgerLovComponent } from './general-leadger-lov.component';

describe('GeneralLeadgerLovComponent', () => {
  let component: GeneralLeadgerLovComponent;
  let fixture: ComponentFixture<GeneralLeadgerLovComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeneralLeadgerLovComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneralLeadgerLovComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
