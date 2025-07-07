import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth/auth-service';
import { Router } from '@angular/router';
import { App } from '../../app';
import { DecodedJwt } from '../../models/decoded-jwt';

@Component({
    selector: 'app-login',
    imports: [CommonModule, FormsModule],
    templateUrl: './login.html',
    styleUrl: './login.scss'
})
export class Login {
    credentials = { username: '', password: '' };
    errorMessage = '';
    loading = true;
    user: DecodedJwt | null = null;
    userRoles: string[] = [];

    constructor(public auth: AuthService, public app: App) {}

    async ngOnInit() {
        this.loading = true;
        const valid = await this.auth.isLoggedIn();
        if (valid) {
            this.user = this.auth.getUser();
            this.userRoles = this.auth.getUserRoles();
        } else {
            // this.auth.logout();
            this.user = null;
            this.userRoles = [];
        }
        this.loading = false;
    }

    login() {
        this.errorMessage = '';
        this.loading = true;
        this.auth.login(this.credentials.username, this.credentials.password).subscribe({
            next: () => {
                this.user = this.auth.getUser();
                this.userRoles = this.auth.getUserRoles();
                this.loading = false;
                localStorage.setItem('showLoginBanner', '1');
                window.location.reload();
                // this.banner.show('Logged in successfully!'); // Now handled after reload
            },
            error: () => {
                this.loading = false;
                this.errorMessage = 'Invalid username or password.';
            }
        });
    }

    logout() {
        this.auth.logout();
        this.user = null;
        this.userRoles = [];
        if (typeof window !== 'undefined' && window.localStorage) {
            localStorage.removeItem('loginTime');
        }
        // this.router.navigate(['/login']);
        this.loading = false;
    }

    isLoggedIn() {
        return !this.loading && this.auth.isLoggedIn();
    }
}
