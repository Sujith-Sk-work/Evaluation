import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import{Request} from '../shared/request';
import { Requestmodel } from './requestmodel';


@Injectable({
  providedIn: 'root'
})
export class RequestService {

  formData:Requestmodel=new Requestmodel;
  requests:Requestmodel[];



  constructor(private httpClient:HttpClient) { }

  //get all requests
  bindRequests(){
    this.httpClient.get(environment.apiUrl + "/api/request")
    .toPromise().then(

      Response => this.requests = Response as Requestmodel[]
    )
  }

  //Get Request
  getRequest(){
    
  }

}
