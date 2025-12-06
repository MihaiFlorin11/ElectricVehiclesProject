import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../entities/user';
import { UserService } from '../services/users/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) {}

  hide = true;
  loginForm!: FormGroup;
  emailRegex = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  user!: User;

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: [null, [Validators.required, Validators.pattern(this.emailRegex)]],
      password: [null, Validators.required]
    });
  }

  loginUser(): void {
    this.userService.loginUser(this.loginForm.value).subscribe(
      (data) => {
        this.user = data;
        if(this.user.role === 'Administrator') {
          this.router.navigate(['/admin-main-page']);
        }
        else {
          this.router.navigate(['/user-main-page']);
        } 
      });
  }

  submit(): void {
    if (!this.loginForm.valid) {
      return;
    }
    else {
      localStorage.setItem("auth", "true");
      this.loginUser();
    }
  }

}
