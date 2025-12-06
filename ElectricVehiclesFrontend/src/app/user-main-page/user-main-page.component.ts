import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/users/user.service';
import { Rental } from '../entities/rental';
import { VehicleService } from '../services/vehicles/vehicle.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvoiceService } from '../services/invoices/invoice.service';
import { RentalService } from '../services/rentals/rental.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-user-main-page',
  templateUrl: './user-main-page.component.html',
  styleUrls: ['./user-main-page.component.css']
})
export class UserMainPageComponent implements OnInit {
  
  constructor(private formBuilder: FormBuilder, private vehicleService: VehicleService, private userService: UserService, private invoiceService: InvoiceService, private rentalService: RentalService, private snackBar: MatSnackBar) {}

  vehicleId!: number;
  userId!: number;
  invoiceId!: number;
  startDateTime!: string;
  endDateTime!: string;
  createForm!: FormGroup;
  legendVehicles = [
    {id: 1, type: "ClassicBike"},
    {id: 2, type: "ElectricBike"},
    {id: 3, type: "ClassicScooter"},
    {id: 4, type: "ElectricScooter"},
    {id: 5, type: "ClassicCar"},
    {id: 6, type: "ElectricCar"},
  ];

  ngOnInit(): void {

    this.createForm = this.formBuilder.group({
      startDateTime: [null, Validators.required],
      endDateTime: [null, Validators.required]
    });
  }

  selectVehicle(value: number) {
    this.vehicleId = value;
  }

  submit(): void {
    if (!this.createForm.valid) {
      return;
    }
    else {    
      let rental: Rental = {
        id: 0,
        vehicleId: 21,
        userId: 2,
        invoiceId: 21,
        startDateTime: this.createForm.value['startDateTime'],
        endDateTime: this.createForm.value['endDateTime']
      };
      this.rentalService.createRental(rental).subscribe();
      this.snackBar.open('Rental created', 'Close', {
        duration: 4000,
        verticalPosition: 'top',
        horizontalPosition: 'right'
      });
    }
  }

}
