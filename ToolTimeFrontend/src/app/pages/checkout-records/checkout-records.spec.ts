import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutRecords } from './checkout-records';

describe('CheckoutRecords', () => {
  let component: CheckoutRecords;
  let fixture: ComponentFixture<CheckoutRecords>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CheckoutRecords]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CheckoutRecords);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
