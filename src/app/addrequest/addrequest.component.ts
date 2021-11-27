import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Request } from '../shared/request';
import { RequestService } from '../shared/request.service';

@Component({
  selector: 'app-addrequest',
  templateUrl: './addrequest.component.html',
  styleUrls: ['./addrequest.component.css']
})
export class AddrequestComponent implements OnInit {

  requestId: number;
  request: Request = new Request;

  constructor(public requestService: RequestService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {

    //get user Id from the form
    this.requestId = this.route.snapshot.params['RequestId']

    //Populate the form while updating
    if (this.requestId != 0 || this.requestId != null) {
      //Get User
      this.requestService.getRequest(this.requestId).subscribe(

        data => {
          console.log(data);

          this.requestService.formData = Object.assign({}, data);
        },
        error => console.log(error)

      );
    }
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.requestService.formData.RequestId;
    //INSERT
    if (addId == 0 || addId == null) {

      console.log("Inserting record")
      this.insertRequestRecord(form);
    }
    else {
      //UPDATE
      console.log("Updating record")
      this.updateRequestRecord(form);
    }
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //INSERT
  insertRequestRecord(form: NgForm) {
    console.log("Inserting a record...."); // For testing

    this.requestService.addRequest(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
      }
    );
    //window.location.reload();
  }


  //UPDATE
  updateRequestRecord(form: NgForm) {
    console.log("Updating a record...."); // For testing
    this.requestService.updateRequest(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);

      }
    );
    //window.location.reload();
  }
}
