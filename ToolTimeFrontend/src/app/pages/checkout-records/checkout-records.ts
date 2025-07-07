import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CheckoutRecordsApi } from '../../services/checkout-records/checkout-records-api';
import { CheckoutRecord } from '../../models/checkoutRecord';
import { AuthService } from '../../services/auth/auth-service';
import { FormsModule } from '@angular/forms';
import { ToolsApi } from '../../services/tools/tools-api';
import { Tool } from '../../models/tool';

@Component({
  selector: 'app-checkout-records',
  imports: [CommonModule, FormsModule],
  templateUrl: './checkout-records.html',
  styleUrl: './checkout-records.scss'
})
export class CheckoutRecords {
  checkoutRecords: CheckoutRecord[] = [];
  errorMessage: string = '';
  newCheckoutRecord: Partial<CheckoutRecord> = {};
  isLoggedIn: boolean = false;
  tools: Tool[] = [];
  public auth: AuthService;

  constructor(
    private api: CheckoutRecordsApi,
    auth: AuthService,
    private router: Router,
    private toolsApi: ToolsApi
  ) {
    this.auth = auth;
  }

  ngOnInit() {
    this.isLoggedIn = this.auth.isLoggedIn();
    if (this.isLoggedIn) {
      this.loadCheckoutRecords();
      this.toolsApi.getTools().subscribe(tools => this.tools = tools);
    } else {
      this.errorMessage = 'You must be logged in to view checkout records.';
    }
  }

  loadCheckoutRecords() {
    this.api.getCheckoutRecords().subscribe({
      next: (data) => {
        this.checkoutRecords = data;
      },
      error: (error) => {
        this.errorMessage = 'Failed to load checkout records. Please try again later.';
        console.error('Error loading checkout records:', error);
      }
    });
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  submitCheckoutRecord() {
    if (!this.newCheckoutRecord.toolId || !this.newCheckoutRecord.expectedReturnDateTime) {
      this.errorMessage = 'Tool and expected return date are required.';
      return;
    }
    const record: Partial<CheckoutRecord> = {
      toolId: this.newCheckoutRecord.toolId,
      userId: this.auth.getUser()?.id ?? '', // userId as string
      checkoutDateTime: new Date().toISOString(), // property name per backend
      expectedReturnDateTime: this.newCheckoutRecord.expectedReturnDateTime // property name per backend
      // actualReturn is omitted on creation
    };
    this.api.createCheckoutRecord(record).subscribe({
      next: () => {
        this.errorMessage = '';
        this.newCheckoutRecord = {};
        this.loadCheckoutRecords();
      },
      error: (error) => {
        this.errorMessage = 'Failed to submit checkout record. Please try again.';
        console.error('Error submitting checkout record:', error);
      }
    });
  }

  returnCheckoutRecord(id: number) {
    this.api.returnCheckoutRecord(id).subscribe({
      next: () => {
        this.loadCheckoutRecords();
      },
      error: (error) => {
        this.errorMessage = 'Failed to return checkout record. Please try again.';
        console.error('Error returning checkout record:', error);
      }
    });
  }
}
