import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';


import {HomeComponent} from './components/home/home.component';
import { BookdetailComponent } from './components/bookdetail/bookdetail.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';

const routes:Routes=[
  {path:'',redirectTo:'home', pathMatch:'full', },
  { path: 'home', component: HomeComponent },
  { path: 'view/:id', component: BookdetailComponent },
  {path:'register', component:RegisterComponent},
  {path:'login', component:LoginComponent}
]

   

@NgModule({
  imports:[RouterModule.forRoot(routes)],
  exports:[RouterModule]
})
export class AppRoutingModule { }
