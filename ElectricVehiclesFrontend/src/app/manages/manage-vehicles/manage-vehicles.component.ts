import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MAT_DIALOG_DATA, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { VehicleService } from 'src/app/services/vehicles/vehicle.service';
import { DatePipe } from '@angular/common';
import { Vehicle } from 'src/app/entities/vehicle';

@Component({
  selector: 'app-manage-vehicles',
  templateUrl: './manage-vehicles.component.html',
  styleUrls: ['./manage-vehicles.component.css']
})
export class ManageVehiclesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'vehicleType', 'registerDate', 'actions', 'add'];
  dataSource: MatTableDataSource<Vehicle> = new MatTableDataSource<Vehicle>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  vehicle: Vehicle = {
    id: 0,
    vehicleType: '',
    registerDate: '',
  };
  

  constructor(private vehicleService: VehicleService, private dialog: MatDialog, private datePipe: DatePipe) {}

  ngOnInit(): void {
    this.vehicleService.getVehicles().subscribe(
      (data) => {
        data.forEach(item => {
          item.registerDate = this.datePipe.transform(item.registerDate, 'dd/MM/yyyy') as string;
        });
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  refreshTable(): void {
    this.vehicleService.getVehicles().subscribe(
      (data) => {
        data.forEach(item => {
          item.registerDate = this.datePipe.transform(item.registerDate, 'dd/MM/yyyy') as string;
        });
        this.dataSource.data = data;
    });
  }

  openDialogForCreate(): void {
    this.dialog.open(CreateVehicleDialog, {
      data: {
        vehicleType: this.vehicle.vehicleType,
        registerDate: this.vehicle.registerDate,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForView(id: number): void {
    this.dialog.open(ViewVehicleDialog, {
      data: {
        id: id,
      }
    });
  }

  openDialogForUpdate(id: number, vehicleType: string, registerDate: string): void {
    this.dialog.open(UpdateVehicleDialog, {
      data: {
        id: id,
        vehicleType: vehicleType,
        registerDate: registerDate,        
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForDelete(id: number): void {
    this.dialog.open(DeleteVehicleDialog, {
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
  selector: 'create-vehicle-dialog',
  templateUrl: 'create-vehicle-dialog.html',
})
export class CreateVehicleDialog implements OnInit {

  createForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<CreateVehicleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Vehicle, private formBuilder: FormBuilder,
    private vehicleService: VehicleService) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      vehicleType: [null, Validators.required],
      registerDate: [null, Validators.required],
    });
  }

  submit() {
    if (!this.createForm.valid) {
      return;
    }
    else {
      this.vehicleService.createVehicle(this.createForm.value).subscribe();
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'view-vehicle-dialog',
  templateUrl: 'view-vehicle-dialog.html',
})
export class ViewVehicleDialog implements OnInit {

  vehicle: Vehicle = {
    id: 0,
    vehicleType: '',
    registerDate: '',
  };

  constructor(public dialogRef: MatDialogRef<ViewVehicleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Vehicle, 
    private vehicleService: VehicleService, private datePipe: DatePipe) {}

  ngOnInit(): void {
    this.vehicleService.getVehicleById(this.data.id).subscribe(
      (data) => {
        this.vehicle.id = data.id;
        this.vehicle.vehicleType = data.vehicleType;
        this.vehicle.registerDate = this.datePipe.transform(data.registerDate, 'dd/MM/yyyy') as string;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}

@Component({
  selector: 'update-vehicle-dialog',
  templateUrl: 'update-vehicle-dialog.html',
})
export class UpdateVehicleDialog implements OnInit {

  updateForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<UpdateVehicleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Vehicle, private formBuilder: FormBuilder,
    private vehicleService: VehicleService) {}

  ngOnInit(): void {
      this.updateForm = this.formBuilder.group({
        id: this.data.id,
        vehicleType: [this.data.vehicleType, Validators.required],
        registerDate: [this.data.registerDate, Validators.required]
      });
    }

    submit() {
      if (!this.updateForm.valid) {
        return;
      }
      else {
        this.vehicleService.updateVehicle(this.data.id, this.updateForm.value).subscribe();
      }
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

}

@Component({
  selector: 'delete-vehicle-dialog',
  templateUrl: 'delete-vehicle-dialog.html',
})
export class DeleteVehicleDialog implements OnInit {
  
    vehicle: Vehicle = {
    id: 0,
    vehicleType: '',
    registerDate: '',
  };

  constructor(
    public dialogRef: MatDialogRef<DeleteVehicleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: Vehicle,
    private vehicleService: VehicleService) {}

  ngOnInit(): void {
      
  }

  submit() {
    console.log(this.data.id);
    this.vehicleService.deleteVehicle(this.data.id).subscribe();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}