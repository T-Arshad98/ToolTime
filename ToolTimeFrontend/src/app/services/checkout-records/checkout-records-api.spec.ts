import { TestBed } from '@angular/core/testing';

import { CheckoutRecordsApi } from './checkout-records-api';

describe('CheckoutRecordsApi', () => {
  let service: CheckoutRecordsApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CheckoutRecordsApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
