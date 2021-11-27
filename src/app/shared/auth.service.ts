import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../shared/user';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient, private router: Router) { }

  //Get an user
  getUserByPassword(user: User): Observable<any> {
    //console.log(user.UserName);
    //console.log(user.UserPassword);
    return this.httpClient.get(environment.apiUrl + "/api/login/getuser/" + user.UserName + "/" + user.UserPassword);

  }

  //Authorize --return token with Role id and username
  public loginVerify(user: User) {
    //calling webservice
    console.log("Attempt authentication and authorize :");
    console.log(user);
    return this.httpClient.get(environment.apiUrl + "/api/login/" + user.UserName + "/" + user.UserPassword);

  }

  //Logout
  public logOut() {
    localStorage.removeItem('userName');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('jwtToken');
  }

}
