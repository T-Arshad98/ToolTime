import { TestBed } from '@angular/core/testing';

import { ToolsApi } from './tools-api';

describe('ToolsApi', () => {
  let service: ToolsApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ToolsApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
