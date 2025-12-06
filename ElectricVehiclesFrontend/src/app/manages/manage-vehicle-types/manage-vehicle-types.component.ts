import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import {MAT_DIALOG_DATA, MatDialogRef, MatDialog} from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { VehicleTypes } from 'src/app/entities/vehicle-types';
import { VehicleTypesService } from 'src/app/services/vehicle-types/vehicle-types.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-manage-vehicle-types',
  templateUrl: './manage-vehicle-types.component.html',
  styleUrls: ['./manage-vehicle-types.component.css']
})

export class ManageVehicleTypesComponent implements OnInit {

  displayedColumns: string[] = ['id', 'description', 'type', 'pricePerMinute', 'actions', 'add'];
  dataSource: MatTableDataSource<VehicleTypes> = new MatTableDataSource<VehicleTypes>([]);
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  vehicleTypes: VehicleTypes = {
    id: 0,
    description: '',
    type: '',
    pricePerMinute: 0,
  };
  

  constructor(private vehicleTypesService: VehicleTypesService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.vehicleTypesService.getVehicleTypes().subscribe(
      (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
  }

  refreshTable(): void {
    this.vehicleTypesService.getVehicleTypes().subscribe(
      (data) => {
        this.dataSource.data = data;
    });
  }

  openDialogForCreate(): void {
    this.dialog.open(CreateVehicleTypesDialog, {
      data: {
        description: this.vehicleTypes.description,
        type: this.vehicleTypes.type,
        pricePerMinute: this.vehicleTypes.pricePerMinute,
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForView(id: number): void {
    this.dialog.open(ViewVehicleTypesDialog, {
      data: {
        id: id,
      }
    });
  }

  openDialogForUpdate(id: number, description: string, type: string, pricePerMinute: number): void {
    this.dialog.open(UpdateVehicleTypesDialog, {
      data: {
        id: id,
        description: description,
        type: type,
        pricePerMinute: pricePerMinute,        
      }
    });
    this.dialog.afterAllClosed.subscribe(() => {
      this.refreshTable();
    });
  }

  openDialogForDelete(id: number): void {
    this.dialog.open(DeleteVehicleTypesDialog, {
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
  selector: 'create-vehicle-types-dialog',
  templateUrl: 'create-vehicle-types-dialog.html',
})
export class CreateVehicleTypesDialog implements OnInit {

  createForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<CreateVehicleTypesDialog>,
    @Inject(MAT_DIALOG_DATA) public data: VehicleTypes, private formBuilder: FormBuilder,
    private vehicleTypesService: VehicleTypesService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
    this.createForm = this.formBuilder.group({
      description: [null, Validators.required],
      type: [null, Validators.required],
      pricePerMinute: [null, Validators.required],
    });
  }

  submit() {
    if (!this.createForm.valid) {
      return;
    }
    else {
      this.vehicleTypesService.createVehicleType(this.createForm.value).subscribe();
      this.snackBar.open('Vehicle type created', 'Close', {
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
  selector: 'view-vehicle-types-dialog',
  templateUrl: 'view-vehicle-types-dialog.html',
})
export class ViewVehicleTypesDialog implements OnInit {

  vehicleTypes: VehicleTypes = {
    id: 0,
    description: '',
    type: '',
    pricePerMinute: 0,
  };

  constructor(public dialogRef: MatDialogRef<ViewVehicleTypesDialog>,
    @Inject(MAT_DIALOG_DATA) public data: VehicleTypes, 
    private vehicleTypesService: VehicleTypesService) {}

  ngOnInit(): void {
    this.vehicleTypesService.getVehicleTypeById(this.data.id).subscribe(
      (data) => {
        this.vehicleTypes.id = data.id;
        this.vehicleTypes.description = data.description;
        this.vehicleTypes.type = data.type;
        this.vehicleTypes.pricePerMinute = data.pricePerMinute;
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
  
}

@Component({
  selector: 'update-vehicle-types-dialog',
  templateUrl: 'update-vehicle-types-dialog.html',
})
export class UpdateVehicleTypesDialog implements OnInit {

  updateForm!: FormGroup;
  hide = true;

  constructor(
    public dialogRef: MatDialogRef<UpdateVehicleTypesDialog>,
    @Inject(MAT_DIALOG_DATA) public data: VehicleTypes, private formBuilder: FormBuilder,
    private vehicleTypesService: VehicleTypesService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
      this.updateForm = this.formBuilder.group({
        id: this.data.id,
        description: [this.data.description, Validators.required],
        type: [this.data.type, Validators.required],
        pricePerMinute: [this.data.pricePerMinute, Validators.required],
      });
    }

    submit() {
      if (!this.updateForm.valid) {
        return;
      }
      else {
        this.vehicleTypesService.updateVehicleType(this.data.id, this.updateForm.value).subscribe();
        this.snackBar.open('Vehicle type updated', 'Close', {
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
  selector: 'delete-vehicle-types-dialog',
  templateUrl: 'delete-vehicle-types-dialog.html',
})
export class DeleteVehicleTypesDialog implements OnInit {
  
    vehicle: VehicleTypes = {
    id: 0,
    description: '',
    type: '',
    pricePerMinute: 0,
  };

  constructor(
    public dialogRef: MatDialogRef<DeleteVehicleTypesDialog>,
    @Inject(MAT_DIALOG_DATA) public data: VehicleTypes,
    private vehicleTypesService: VehicleTypesService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
      
  }

  submit() {
    this.vehicleTypesService.deleteVehicleType(this.data.id).subscribe();
    this.snackBar.open('Vehicle type deleted', 'Close', {
      duration: 4000,
      verticalPosition: 'top',
      horizontalPosition: 'right'
    });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}