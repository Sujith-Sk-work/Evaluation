import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Request } from '../shared/request';
import { Requestmodel } from './requestmodel'; 


@Injectable({
  providedIn: 'root'
})
export class RequestService {

  formData: Requestmodel = new Requestmodel;
  formData1:Request=new Request;
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
  getRequest(id): Observable<any> {
    return this.httpClient.get(environment.apiUrl + "/api/getreq/" + id);
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
