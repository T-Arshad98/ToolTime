import { TestBed } from '@angular/core/testing';

import { MaintenanceRequestsApi } from './maintenance-requests-api';

describe('MaintenanceRequestsApi', () => {
  let service: MaintenanceRequestsApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaintenanceRequestsApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
