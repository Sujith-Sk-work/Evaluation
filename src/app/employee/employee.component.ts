import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  loggedUserName:string

  constructor(private authService:AuthService,private router:Router) { }

  ngOnInit(): void {
    this.loggedUserName=localStorage.getItem("userName");

  }

  //logout method
  logOut(){
    this.authService.logOut();
    this.router.navigateByUrl('');
  }
} 
