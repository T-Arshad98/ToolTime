import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { AuthService } from './auth-service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService) {}

  canActivate(): boolean {
    if (this.auth.isTokenValid()) {
      return true;
    } else {
      window.location.reload();
      return false;
    }
  }
}
