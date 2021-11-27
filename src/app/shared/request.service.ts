import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Request } from '../shared/request';
import { Requestmodel } from './requestmodel';


@Injectable({
  providedIn: 'root'
})
export class RequestService {

  formData: Requestmodel = new Requestmodel;
  requests: Requestmodel[];
  request: Request;



  constructor(private httpClient: HttpClient) { }

  //get all requests
  bindRequests() {
    this.httpClient.get(environment.apiUrl + "/api/request")
      .toPromise().then(

        Response => this.requests = Response as Requestmodel[]
      )
  }

  //Get Request
  getRequest(id) {
    this.httpClient.get(environment.apiUrl + "/api/getreq")
      .toPromise().then(
        Response => this.request = Response as Request
      )
  }

  //Add request
  addRequest(request: Request) {
    return this.httpClient.post(environment.apiUrl + "/api/request", request);
  }

  //Update Request
  updateRequest(request: Request) {
    return this.httpClient.put(environment.apiUrl + "/api/request", request);
  }

  //Delete Requess
  deleteRequest(id: number) {
    return this.httpClient.delete(environment.apiUrl + "/api/request/" + id);
  }

}
