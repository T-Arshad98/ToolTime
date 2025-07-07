import { Component, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth/auth-service';
import { CheckoutRecordsApi } from '../../services/checkout-records/checkout-records-api';
import { MaintenanceRequestsApi } from '../../services/maintenance-requests/maintenance-requests-api';
import { DecodedJwt } from '../../models/decoded-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.html',
  styleUrl: './home.scss'
})
export class Home implements AfterViewInit {
  user: DecodedJwt | null = null;
  checkedOutCount: number = 0;
  maintenanceCount: number = 0;
  loginDuration: string = '';
  isLoggedIn: boolean = false;
  private loginTime: number | null = null;
  private durationInterval: any = null;

  constructor(
    private auth: AuthService,
    private checkoutApi: CheckoutRecordsApi,
    private maintenanceApi: MaintenanceRequestsApi,
    private router: Router
  ) { }

  ngOnInit() {
    // Do nothing here for login check
  }

  ngAfterViewInit() {
    setTimeout(() => {
      this.isLoggedIn = this.auth.isLoggedIn();
      if (this.isLoggedIn) {
        this.user = this.auth.getUser();
        if (typeof window !== 'undefined' && window.localStorage) {
          const stored = localStorage.getItem('loginTime');
          this.loginTime = stored ? parseInt(stored, 10) : null;
        }
        this.updateLoginDuration();
        if (this.durationInterval) clearInterval(this.durationInterval);
        this.durationInterval = setInterval(() => this.updateLoginDuration(), 1000);
        this.checkoutApi.getCheckoutRecords().subscribe(records => {
          this.checkedOutCount = records.filter(r => String(r.userId) == this.user!.id).length;
        });
        this.maintenanceApi.getMaintenanceRequests().subscribe(reqs => {
          this.maintenanceCount = reqs.filter(r => r.userId == this.user!.id).length;
        });
      } else {
        this.clearUserState();
        // Optionally: this.errorMessage = 'You must be logged in to view this page.';
      }
    });
  }

  private clearUserState() {
    this.user = null;
    this.loginDuration = '';
    this.checkedOutCount = 0;
    this.maintenanceCount = 0;
    if (this.durationInterval) {
      clearInterval(this.durationInterval);
      this.durationInterval = null;
    }
  }

  ngOnDestroy() {
    this.clearUserState();
  }

  updateLoginDuration() {
    if (this.loginTime && this.user) {
      const ms = Date.now() - this.loginTime;
      const totalSeconds = Math.floor(ms / 1000);
      const hours = Math.floor(totalSeconds / 3600);
      const minutes = Math.floor((totalSeconds % 3600) / 60);
      const seconds = totalSeconds % 60;
      this.loginDuration = `${hours}h ${minutes}m ${seconds}s`;
    } else {
      this.loginDuration = '';
    }
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }

  goToPage(page: string) {
    this.router.navigate([`/${page}`]);
  }
}
