import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/entities/user';
import { UserService } from 'src/app/services/users/user.service';
import {MAT_DIALOG_DATA, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.css']
})
export class ManageUsersComponent implements OnInit {

  displayedColumns: string[] = ['id', 'username', 'email', 'password', 'role', 'actions', 'add'];
  dataSource: MatTableDataSource<User> = new MatTableDataSource<User>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  user: User = {
    id: 0,
    username: '',
    email: '',
    password: '',
    role: ''
  };
  

  constructor(private userService: UserService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe(
      (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  refreshTable(): void {
    this.userService.getUsers().subscribe(
      (data) => {
        this.dataSource.data = data;
    });
  }

  openDialogForCreate(): void {
    this.dialog.open(CreateUserDialog, {
      data: {
        username: this.user.username,
        email: this.user.email,
        password: this.user.password,
        role: this.user.role
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForView(id: number): void {
    this.dialog.open(ViewUserDialog, {
      data: {
        id: id,
      }
    });
  }

  openDialogForUpdate(id: number, username: string, email: string, password: string, role: string): void {
    this.dialog.open(UpdateUserDialog, {
      data: {
        id: id,
        username: username,
        email: email,
        password: password,
        role: role,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForDelete(id: number): void {
    this.dialog.open(DeleteUserDialog, {
      data: {
        id: id,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }
}

@Component({
  selector: 'create-user-dialog',
  templateUrl: 'create-user-dialog.html',
})
export class CreateUserDialog implements OnInit {

  createForm!: FormGroup;
  emailRegex = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<CreateUserDialog>,
    @Inject(MAT_DIALOG_DATA) public data: User, private formBuilder: FormBuilder,
    private userService: UserService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      username: [null, Validators.required],
      email: [null, [Validators.required, Validators.pattern(this.emailRegex)]],
      password: [null, Validators.required],
      role: [null, Validators.required]
    });
  }

  submit() {
    if (!this.createForm.valid) {
      return;
    }
    else {
      this.userService.createUser(this.createForm.value).subscribe();
      this.snackBar.open('User created', 'Close', {
        duration: 4000,
        verticalPosition: 'top',
        horizontalPosition: 'right'
      });
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'view-user-dialog',
  templateUrl: 'view-user-dialog.html',
})
export class ViewUserDialog implements OnInit {

  user: User = {
    id: 0,
    username: '',
    email: '',
    password: '',
    role: ''
  };

  constructor(public dialogRef: MatDialogRef<ViewUserDialog>,
    @Inject(MAT_DIALOG_DATA) public data: User, 
    private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUserById(this.data.id).subscribe(
      (data) => {
        this.user.id = data.id;
        this.user.username = data.username;
        this.user.email = data.email;
        this.user.password = data.password;
        this.user.role = data.role;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}

@Component({
  selector: 'update-user-dialog',
  templateUrl: 'update-user-dialog.html',
})
export class UpdateUserDialog implements OnInit {

  updateForm!: FormGroup;
  emailRegex = /^(([^<>+()\[\]\\.,;:\s@"-#$%&=]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,3}))$/;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<UpdateUserDialog>,
    @Inject(MAT_DIALOG_DATA) public data: User, private formBuilder: FormBuilder,
    private userService: UserService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
      this.updateForm = this.formBuilder.group({
        id: this.data.id,
        username: [this.data.username, Validators.required],
        email: [this.data.email, [Validators.required, Validators.pattern(this.emailRegex)]],
        password: [this.data.password, Validators.required],
        role: [this.data.role, Validators.required]
      });
    }

  submit() {
    if (!this.updateForm.valid) {
      return;
    }
    else {
      this.userService.updateUser(this.data.id, this.updateForm.value).subscribe();
      this.snackBar.open('User updated', 'Close', {
        duration: 4000,
        verticalPosition: 'top',
        horizontalPosition: 'right'
      });
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'delete-user-dialog',
  templateUrl: 'delete-user-dialog.html',
})
export class DeleteUserDialog implements OnInit {
  
    user: User = {
    id: 0,
    username: '',
    email: '',
    password: '',
    role: ''
  };

  constructor(
    public dialogRef: MatDialogRef<DeleteUserDialog>,
    @Inject(MAT_DIALOG_DATA) public data: User,
    private userService: UserService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
      
  }

  submit() {
    this.userService.deleteUser(this.data.id).subscribe();
    this.snackBar.open('User deleted', 'Close', {
      duration: 4000,
      verticalPosition: 'top',
      horizontalPosition: 'right'
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}