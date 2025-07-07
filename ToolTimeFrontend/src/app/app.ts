import { Component, OnInit, OnDestroy, NgZone } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import { Header } from "./pages/header/header";
import { Footer } from "./pages/footer/footer";
import { AuthService } from './services/auth/auth-service';
import { BannerService } from './services/banner.service';
import { CommonModule } from '@angular/common';
import { DecodedJwt } from './models/decoded-jwt';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Footer, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit, OnDestroy {
  protected title = 'ToolTimeFrontend';
  private tokenCheckInterval: any;
  bannerMessage: string | null = null;
  private bannerSub: any;
  
  user: DecodedJwt | null = null;
  isLoggedIn: boolean = false;

  constructor(
    private auth: AuthService,
    private router: Router,
    private banner: BannerService,
    private ngZone: NgZone
  ) { }

  ngOnInit() {
    this.bannerSub = this.banner.message$.subscribe(msg => this.bannerMessage = msg);
    // Show login banner if flag is set
    if (typeof window !== 'undefined' && window.localStorage) {
      if (localStorage.getItem('showLoginBanner')) {
        this.banner.show('Logged in successfully!');
        localStorage.removeItem('showLoginBanner');
      }
      if (localStorage.getItem('showLogoutBanner')) {
        this.banner.show('Logged out');
        localStorage.removeItem('showLogoutBanner');
      }
    }
    // Global token validity check
    // Periodically check token validity only if logged in

    this.user = this.auth.getUser();
    this.isLoggedIn = this.auth.isLoggedIn();
    if (this.user != null && this.isLoggedIn) {
      this.ngZone.runOutsideAngular(() => {
        this.tokenCheckInterval = setInterval(() => {
          if (!this.auth.isTokenValid()) {
            this.ngZone.run(() => {
              this.isLoggedIn = false;
              this.user = null;
              clearInterval(this.tokenCheckInterval);
              this.auth.logout(); // Only navigate and show banner, do not reload
            });
          }
        }, 1000); // check every 1 second for better accuracy
      });
    }
  }

  ngOnDestroy() {
    if (this.bannerSub) this.bannerSub.unsubscribe();
    if (this.tokenCheckInterval) clearInterval(this.tokenCheckInterval);
  }

  closeBanner() {
    this.bannerMessage = null;
    this.banner.clear();
  }
}
