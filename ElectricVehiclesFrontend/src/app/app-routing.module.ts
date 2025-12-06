import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ActionComponent } from './action/action.component';
import { RegisterComponent } from './register/register.component';
import { ManageUsersComponent } from './manages/manage-users/manage-users.component';
import { ManageVehiclesComponent } from './manages/manage-vehicles/manage-vehicles.component';
import { AdminMainPageComponent } from './admin-main-page/admin-main-page.component';
import { UserMainPageComponent } from './user-main-page/user-main-page.component';
import { ManageVehicleTypesComponent } from './manages/manage-vehicle-types/manage-vehicle-types.component';
import { ManageInvoicesComponent } from './manages/manage-invoices/manage-invoices.component';
import { ManageRentalsComponent } from './manages/manage-rentals/manage-rentals.component';
import { AuthGuardService } from './services/auth-guard/auth.guard.service';

const routes: Routes = [
  { path: 'admin-main-page', component: AdminMainPageComponent},
  { path: 'user-main-page', component: UserMainPageComponent},
  { path: 'action', component: ActionComponent},
  { path: 'admin-main-page', component: AdminMainPageComponent},
  { path: 'manage-users', component: ManageUsersComponent},
  { path: 'manage-vehicles', component: ManageVehiclesComponent},
  { path: 'manage-vehicle-types', component: ManageVehicleTypesComponent},
  { path: 'manage-invoices', component: ManageInvoicesComponent},
  { path: 'manage-rentals', component: ManageRentalsComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'login', component: LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
