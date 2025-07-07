import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { Api } from '../api';
import { User } from '../../models/user';
import { jwtDecode } from 'jwt-decode';
import { DecodedJwt } from '../../models/decoded-jwt';
import { Router } from '@angular/router';
import { BannerService } from '../banner.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends Api {

  private tokenkey = 'auth-token';
  constructor(private http: HttpClient, private router: Router, private banner: BannerService) {
    super();
  }

  /**
   * Logs in a user with the provided username and password.
   * @param username The username of the user.
   * @param password The password of the user.
   * @returns An Observable that emits the login response.
   */
  login(username: string, password: string): Observable<{ token: string, user?: any }> {
    // The backend expects a User object with Username and Password
    return this.http.post<{ token: string }>(`${this.baseUrl}/auth/login`, { Username: username, Password: password })
      .pipe(
        tap(response => {
          if (typeof window !== 'undefined' && window.localStorage) {
            // Store the token in local storage
            localStorage.setItem(this.tokenkey, response.token);
            // Decode the token and extract user info
            const decoded: any = jwtDecode(response.token);
            // Claims: name (username), nameidentifier (id), role (array or string)
            const user = {
              username: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"],
              id: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"],
              roles: Array.isArray(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]) ?
                decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] :
                decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] ? [decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]] : []
            };
            localStorage.setItem('user', JSON.stringify(user));
            // Set loginTime immediately after successful login
            localStorage.setItem('loginTime', Date.now().toString());
            // Remove any stale logout banner flag
            localStorage.removeItem('showLogoutBanner');
          }
        })
      );
  }

  /**
   * Checks if the user is authenticated by verifying the presence of a token.
   * @returns True if the user is authenticated, false otherwise.
   */
  logout(): void {
    if (typeof window !== 'undefined' && window.localStorage) {
      // Remove the token from local storage or service only if it exists
      if (localStorage.getItem(this.tokenkey)) {
        localStorage.removeItem(this.tokenkey);
      }
      if (localStorage.getItem('user')) {
        localStorage.removeItem('user');
      }
      if (localStorage.getItem('loginTime')) {
        localStorage.removeItem('loginTime');
      }
      // Set flag to show logout banner after navigation
      localStorage.setItem('showLogoutBanner', '1');
      window.location.href = '/login';
    }

  }

  /**
   * Checks if the JWT token is present and not expired.
   * @returns True if the token is valid, false otherwise.
   */
  getToken(): string | null {
    if (typeof window !== 'undefined' && window.localStorage) {
      return localStorage.getItem(this.tokenkey);
    }
    return null;
  }

  /**
   * Checks if the JWT token is present and not expired.
   * @returns True if the token is valid, false otherwise.
   */
  isTokenValid(): boolean {
    const token = this.getToken();
    if (!token || token == null) {
      // console.warn('[AuthService] No token found');
      return false;
    }
    try {
      const decoded: any = jwtDecode(token);
      if (!decoded || !decoded.exp) {
        console.warn('[AuthService] Token missing exp claim', decoded);
        return false;
      }
      const now = Math.floor(Date.now() / 1000);
      const valid = decoded.exp > now;
      if (!valid) {
        console.warn(`[AuthService] Token expired: exp=${decoded.exp}, now=${now}`);
      }
      return valid;
    } catch (e) {
      console.error('[AuthService] Token validation failed:', e);
      return false;
    }
  }

  /**
   * Checks if the user is logged in by verifying the presence and validity of a token.
   * @returns True if the user is logged in, false otherwise.
   */
  isLoggedIn(): boolean {
    const valid = this.isTokenValid();
    console.log('[AuthService] isLoggedIn:', valid);
    return valid;
  }

  getUser(): DecodedJwt | null {
    if (typeof window !== 'undefined' && window.localStorage) {
      const user = localStorage.getItem('user');
      return user ? JSON.parse(user) : null;
    }
    return null;
  }

  getUserRoles(): string[] {
    const user = this.getUser();
    if (user && user['roles']) {
      return user.roles;
    }
    return [];
  }

}
