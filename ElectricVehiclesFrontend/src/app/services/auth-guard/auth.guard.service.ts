import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  constructor(private router: Router) {}

  isAuthenticated(): boolean{
    if (localStorage.getItem('auth') === 'true') {
      return true;
    }
    else{
      return false;
    }
  }

  canActivate(): boolean {
    if (!this.isAuthenticated()) {
      this.router.navigate(['/action']);
      return false;
    }
    return true;
  }

}