import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {UserModel} from 'src/app/models/user.model'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private router : Router) { }
  

  userModel = new UserModel();

  ngOnInit(): void {
  }
  onSignIn(){
    this.router.navigate(['/login'],{replaceUrl:true})
  }

}
