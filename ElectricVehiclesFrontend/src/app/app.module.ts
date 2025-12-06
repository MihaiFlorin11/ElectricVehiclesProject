import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MatInputModule } from '@angular/material/input';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { RegisterComponent } from './register/register.component'
import { MatIconModule } from '@angular/material/icon'; 
import { MatToolbarModule } from '@angular/material/toolbar'; 
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ActionComponent } from './action/action.component';
import { HttpClientModule } from '@angular/common/http';
import { MatSidenavModule } from '@angular/material/sidenav';
import { CreateVehicleDialog, DeleteVehicleDialog, ManageVehiclesComponent, UpdateVehicleDialog, ViewVehicleDialog } from './manages/manage-vehicles/manage-vehicles.component';
import { CreateUserDialog, DeleteUserDialog, ManageUsersComponent, UpdateUserDialog, ViewUserDialog } from './manages/manage-users/manage-users.component'; 
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { AdminMainPageComponent } from './admin-main-page/admin-main-page.component';
import { UserMainPageComponent } from './user-main-page/user-main-page.component';
import { DatePipe } from '@angular/common';
import { CreateVehicleTypesDialog, DeleteVehicleTypesDialog, ManageVehicleTypesComponent, UpdateVehicleTypesDialog, ViewVehicleTypesDialog } from './manages/manage-vehicle-types/manage-vehicle-types.component';
import { CreateInvoiceDialog, DeleteInvoiceDialog, ManageInvoicesComponent, UpdateInvoiceDialog, ViewInvoiceDialog } from './manages/manage-invoices/manage-invoices.component';
import { CreateRentalDialog, DeleteRentalDialog, ManageRentalsComponent, UpdateRentalDialog, ViewRentalDialog } from './manages/manage-rentals/manage-rentals.component';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ActionComponent,
    ManageVehiclesComponent,
    ManageUsersComponent,
    CreateUserDialog,
    ViewUserDialog,
    UpdateUserDialog,
    DeleteUserDialog,
    AdminMainPageComponent,
    UserMainPageComponent,
    CreateVehicleDialog,
    ViewVehicleDialog,
    UpdateVehicleDialog,
    DeleteVehicleDialog,
    ManageVehicleTypesComponent,
    CreateVehicleTypesDialog,
    ViewVehicleTypesDialog,
    UpdateVehicleTypesDialog,
    DeleteVehicleTypesDialog,
    ManageInvoicesComponent,
    CreateInvoiceDialog,
    ViewInvoiceDialog,
    UpdateInvoiceDialog,
    DeleteInvoiceDialog,
    ManageRentalsComponent,
    CreateRentalDialog,
    ViewRentalDialog,
    UpdateRentalDialog,
    DeleteRentalDialog,
  ],
  imports: [
    AppRoutingModule,
    MatInputModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSidenavModule,
    MatTableModule,
    MatDialogModule,
    MatPaginatorModule,
    MatSortModule,
    MatAutocompleteModule,
    MatCheckboxModule,
    MatSelectModule,
    MatSnackBarModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
