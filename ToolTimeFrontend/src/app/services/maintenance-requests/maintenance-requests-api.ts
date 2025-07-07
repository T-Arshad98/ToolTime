import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Api } from '../api';
import { MaintenanceRequest } from '../../models/maintenanceRequest';

@Injectable({
  providedIn: 'root'
})
export class MaintenanceRequestsApi extends Api {

  constructor(private http: HttpClient) {
    super();
  }

  getMaintenanceRequests() {
    return this.http.get<MaintenanceRequest[]>(`${this.baseUrl}/maintenancerequests/active`);
  }

  createMaintenanceRequest(request: Partial<MaintenanceRequest>) {
    return this.http.post<MaintenanceRequest>(`${this.baseUrl}/maintenancerequests`, request);
  }
}
