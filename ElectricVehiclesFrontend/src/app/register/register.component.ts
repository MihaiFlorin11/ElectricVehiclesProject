import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../entities/user';
import { UserService } from '../services/users/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private userService: UserService, private router: Router) {}

  hide = true;
  registerForm!: FormGroup;
  emailRegex = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  user!: User;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.pattern(this.emailRegex)]],
      password: ['', Validators.required]
    });
  }

  registerUser(): void {
    this.userService.registerUser(this.registerForm.value).subscribe(
      (data) => {
        this.user = data;
        console.log(data);
      }
    )
  }

  submit(): void {
    if (!this.registerForm.valid) {
      return;
    }
    else {
      this.registerUser();
      this.router.navigate(['/login']);
    }
    // console.log(this.registerForm.get('username')?.value);
  }
}
