import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { MaintenanceRequestsApi } from '../../services/maintenance-requests/maintenance-requests-api';
import { MaintenanceRequest } from '../../models/maintenanceRequest';
import { AuthService } from '../../services/auth/auth-service';
import { ToolsApi } from '../../services/tools/tools-api';
import { Tool } from '../../models/tool';

@Component({
  selector: 'app-maintenance-requests',
  imports: [CommonModule, FormsModule],
  templateUrl: './maintenance-requests.html',
  styleUrl: './maintenance-requests.scss'
})
export class MaintenanceRequests {
  // Placeholder for maintenance requests data
  maintenanceRequests: MaintenanceRequest[] = [];
  errorMessage: string = '';
  newRequest: Partial<MaintenanceRequest> = {};
  isLoggedIn: boolean = false;
  tools: Tool[] = [];
  public auth: AuthService;

  constructor(
    private api: MaintenanceRequestsApi,
    auth: AuthService,
    private router: Router,
    private toolsApi: ToolsApi
  ) {
    this.auth = auth;
  }

  ngOnInit() {
    this.isLoggedIn = this.auth.isLoggedIn();
    if (this.isLoggedIn) {
      this.loadMaintenanceRequests();
      this.toolsApi.getTools().subscribe(tools => this.tools = tools);
    } else {
      this.errorMessage = 'You must be logged in to view maintenance requests.';
    }
  }

  loadMaintenanceRequests() {
    this.api.getMaintenanceRequests().subscribe({
      next: (data) => {
        this.maintenanceRequests = data;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load maintenance requests. Please try again later.';
        console.error('Error loading maintenance requests:', error);
      }
    });
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  submitRequest() {
    if (!this.newRequest.toolId || !this.newRequest.issueDesc) {
      this.errorMessage = 'Tool ID and Issue Description are required.';
      return;
    }
    const request: Partial<MaintenanceRequest> = {
      toolId: this.newRequest.toolId,
      issueDesc: this.newRequest.issueDesc,
      // Optionally add userId if available from auth
      userId: this.auth.getUser()?.id || '',
      status: 'Pending',
      createdAt: new Date().toISOString()
    };
    this.api.createMaintenanceRequest(request).subscribe({
      next: () => {
        this.errorMessage = '';
        this.newRequest = {};
        this.loadMaintenanceRequests();
      },
      error: (error) => {
        this.errorMessage = 'Failed to submit request. Please try again.';
        console.error('Error submitting request:', error);
      }
    });
  }

}
