import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LogoutService {

  constructor(private router: Router) { }

  logoutUser(): void {
    localStorage.setItem("auth", "false");
    this.router.navigate(['/action']);
  }
}
