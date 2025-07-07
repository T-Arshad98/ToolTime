import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Api } from '../api';
import { CheckoutRecord } from '../../models/checkoutRecord';

@Injectable({
  providedIn: 'root'
})
export class CheckoutRecordsApi extends Api {

  constructor(private http: HttpClient) {
    super();
  }

  getCheckoutRecords() {
    return this.http.get<CheckoutRecord[]>(`${this.baseUrl}/checkoutrecords/active`);
  }

  createCheckoutRecord(record: Partial<CheckoutRecord>) {
    return this.http.post<CheckoutRecord>(`${this.baseUrl}/checkoutrecords`, record);
  }

  returnCheckoutRecord(id: number) {
    return this.http.post(`${this.baseUrl}/checkoutrecords/${id}/return`, {});
  }
}
