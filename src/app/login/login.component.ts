import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { Jwtresponse } from '../shared/jwtresponse';
import { User } from '../shared/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //declare variables
  loginForm!: FormGroup;
  isSubmitted = false;
  loginUser: User = new User();
  error = '';
  jwtResponse: any = new Jwtresponse();


  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {

    //formGroup
    this.loginForm = this.formBuilder.group(

      {
        UserName: ['', [Validators.required, Validators.minLength(2)]],
        UserPassword: ['', [Validators.required]]
      }

    );
  }

  //get controls 
  get formControls() {
    return this.loginForm.controls;
  }

  //verify credentials
  loginCredentials() {
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //Invalid or 
    if (this.loginForm.invalid) {
      return;
    }

    //valid
    if (this.loginForm.valid) {
      //calling method from AuthService     -Authorization
      this.authService.loginVerify(this.loginForm.value)
        .subscribe(data => {
          console.log(data);
          //token with roleid and name
          this.jwtResponse = data;

          //storing in memory
          sessionStorage.setItem("jwtToken",this.jwtResponse.token);

          //check the role --based on role id redirect to respective component

          //check the Role
          if (this.jwtResponse.Role === "Admin") {
            //logged as Admin
            console.log("Admin");

            //storing in localstorage/sessionStorage
            localStorage.setItem("userName", this.jwtResponse.uName);
            sessionStorage.setItem("userName", this.jwtResponse.uName);
            localStorage.setItem("ACCESS_ROLE", this.jwtResponse.Role)
            this.router.navigateByUrl('admin');

          }
          else if (this.jwtResponse.Role === "HRManager") {
            console.log("HR");

            //storing in localstorage/sessionStorage
            localStorage.setItem("userName", this.jwtResponse.uName);
            sessionStorage.setItem("userName", this.jwtResponse.uName);
            localStorage.setItem("ACCESS_ROLE", this.jwtResponse.Role)
            this.router.navigateByUrl('hr');
          }
          else if (this.jwtResponse.Role === "User") {
            console.log("User");

            //storing in localstorage/sessionStorage
            localStorage.setItem("userName", this.jwtResponse.uName);
            sessionStorage.setItem("userName", this.jwtResponse.uName);
            localStorage.setItem("ACCESS_ROLE", this.jwtResponse.Role)
            this.router.navigateByUrl('employee');
          }
          else {
            this.error = "Sorry!....Invalid Authorization"
          }
        },
          error => { this.error = "Invalid User name Or Password. Please SignUp To Login" }
        );
    }

  }
  //login verify test
  loginVerifyTest() {
    if (this.loginForm.valid) {
      this.authService.getUserByPassword(this.loginForm.value)
        .subscribe(
          (data) => {
            console.log(data);
          },
          (error) => {
            console.log(error);
          }
        );
    }
  }
}
