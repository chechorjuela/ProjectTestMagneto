import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {SignInComponent} from "./pages/auth/sign-in/sign-in.component";
import {SignUpComponent} from "./pages/auth/sign-up/sign-up.component";
import {AuthGuard} from "./guard/auth.guard";
import {DashboardComponent} from "./pages/home/dashboard/dashboard.component";
import {MeasurenmentComponent} from "./pages/home/measurenment/measurenment.component";

const routes: Routes = [
  {path: 'signin', component: SignInComponent},
  {path: 'signup', component: SignUpComponent},
  {
    path: 'dashboard',
    canActivate: [AuthGuard],
    children: [
      {path: '', component: DashboardComponent},
      {path: 'measurenment', component: MeasurenmentComponent}

    ],
  },
  {path: '**', component: SignInComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
