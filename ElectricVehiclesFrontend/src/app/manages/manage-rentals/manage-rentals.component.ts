import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MAT_DIALOG_DATA, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { Rental } from 'src/app/entities/rental';
import { RentalService } from 'src/app/services/rentals/rental.service';
import { RentalToDisplay } from 'src/app/entities/rentalToDisplay';

@Component({
  selector: 'app-manage-rentals',
  templateUrl: './manage-rentals.component.html',
  styleUrls: ['./manage-rentals.component.css']
})

export class ManageRentalsComponent implements OnInit {

  displayedColumns: string[] = ['id', 'vehicleType', 'username', 'paidInvoice', 'startDateTime', 'endDateTime', 'actions', 'add'];
  dataSource: MatTableDataSource<RentalToDisplay> = new MatTableDataSource<RentalToDisplay>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  rental: Rental = {
    id: 0,
    vehicleId: 0,
    userId: 0,
    invoiceId: 0,
    startDateTime: '',
    endDateTime: ''
  };

  rentalToDisplay: RentalToDisplay = {
    id: 0,
    vehicleType: '',
    username: '',
    paidInvoice: true,
    startDateTime: '',
    endDateTime: ''
  };
  

  constructor(private rentalService: RentalService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.rentalService.getRentals().subscribe(
      (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  refreshTable(): void {
    this.rentalService.getRentals().subscribe(
      (data) => {
        this.dataSource.data = data;
    });
  }

  openDialogForCreate(): void {
    this.dialog.open(CreateRentalDialog, {
      data: {
        vehicleId: this.rental.vehicleId,
        userId: this.rental.userId,
        invoiceId: this.rental.invoiceId,
        startDateTime: this.rental.startDateTime,
        endDateTime: this.rental.endDateTime
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForView(id: number): void {
    this.dialog.open(ViewRentalDialog, {
      data: {
        id: id,
      }
    });
  }

  openDialogForUpdate(id: number, startDateTime: string, endDateTime: string): void {
    this.dialog.open(UpdateRentalDialog, {
      data: {
        id: id,
        startDateTime: startDateTime,
        endDateTime: endDateTime
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForDelete(id: number): void {
    this.dialog.open(DeleteRentalDialog, {
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
  selector: 'create-rental-dialog',
  templateUrl: 'create-rental-dialog.html',
})
export class CreateRentalDialog implements OnInit {

  createForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<CreateRentalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Rental, private formBuilder: FormBuilder,
    private rentalService: RentalService) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      vehicleId: [null, Validators.required],
      userId: [null, Validators.required],
      invoiceId: [null, Validators.required],
      startDateTime: [null, Validators.required],
      endDateTime: [null, Validators.required]
    });
  }

  submit() {
    if (!this.createForm.valid) {
      return;
    }
    else {
      this.rentalService.createRental(this.createForm.value).subscribe();
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'view-rental-dialog',
  templateUrl: 'view-rental-dialog.html',
})
export class ViewRentalDialog implements OnInit {

  rental: Rental = {
    id: 0,
    vehicleId: 0,
    userId: 0,
    invoiceId: 0,
    startDateTime: '',
    endDateTime: ''
  };

  constructor(public dialogRef: MatDialogRef<ViewRentalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Rental, 
    private rentalService: RentalService) {}

  ngOnInit(): void {
    this.rentalService.getRentalById(this.data.id).subscribe(
      (data) => {
        this.rental.id = data.id;
        this.rental.vehicleId = data.vehicleId;
        this.rental.userId = data.userId;
        this.rental.invoiceId = data.invoiceId;
        this.rental.startDateTime = data.startDateTime;
        this.rental.endDateTime = data.endDateTime;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}

@Component({
  selector: 'update-rental-dialog',
  templateUrl: 'update-rental-dialog.html',
})
export class UpdateRentalDialog implements OnInit {

  updateForm!: FormGroup;
  hide = true;
  rental: Rental = {
    id: 0,
    vehicleId: 0,
    userId: 0,
    invoiceId: 0,
    startDateTime: '',
    endDateTime: ''
  };

  constructor(
    public dialogRef: MatDialogRef<UpdateRentalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Rental, private formBuilder: FormBuilder,
    private rentalService: RentalService) {}

  ngOnInit(): void {
      this.updateForm = this.formBuilder.group({
        id: this.data.id,
        startDateTime: [this.data.startDateTime, Validators.required],
        endDateTime: [this.data.endDateTime, Validators.required],
      });
    }

  submit() {
    if (!this.updateForm.valid) {
      return;
    }
    else {
      this.rentalService.updateRental(this.data.id, this.updateForm.value).subscribe();
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'delete-rental-dialog',
  templateUrl: 'delete-rental-dialog.html',
})
export class DeleteRentalDialog implements OnInit {
  
    rental: Rental = {
    id: 0,
    vehicleId: 0,
    userId: 0,
    invoiceId: 0,
    startDateTime: '',
    endDateTime: ''
  };

  constructor(
    public dialogRef: MatDialogRef<DeleteRentalDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Rental,
    private rentalService: RentalService) {}

  ngOnInit(): void {
      
  }

  submit() {
    this.rentalService.deleteRental(this.data.id).subscribe();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}