import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPageComponent } from './components/admin-page/admin-page.component';
import { CreateBookingComponent } from './components/create-booking/create-booking.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { MyBookingsComponent } from './components/my-bookings/my-bookings.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  {path:'', component: HomeComponent,},
  {path:'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},
  {path:'my-bookings', component: MyBookingsComponent},
  {path:'create-booking/:id', component: CreateBookingComponent},
  {path:'admin-page', component: AdminPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
