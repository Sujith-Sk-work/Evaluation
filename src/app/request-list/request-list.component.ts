import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestService } from '../shared/request.service';

@Component({
  selector: 'app-request-list',
  templateUrl: './request-list.component.html',
  styleUrls: ['./request-list.component.css']
})
export class RequestListComponent implements OnInit {

  //assign default page number
  page: number = 1;
  filter: string;

  constructor(public requestService: RequestService, private router: Router) { }

  ngOnInit(): void {
    //get all users
    this.requestService.bindRequests();
  }

}
