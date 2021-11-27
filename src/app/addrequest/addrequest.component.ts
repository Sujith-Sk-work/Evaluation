import { Component, OnInit } from '@angular/core';
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
      this.requestService.getUser(this.userId).subscribe(

        data => {
          console.log(data);

          this.userService.formData = Object.assign({}, data);
        },
        error => console.log(error)

      );
    }
  }
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.userService.formData.UserId;
    //INSERT
    if (addId == 0 || addId == null) {
      this.insertUserRecord(form);
      this.router.navigate(['/hobby', this.userService.formData.UserId])
    }
    else {
      //UPDATE
      console.log("Updating record")
      this.updateUserRecord(form);
    }

    //form.resetForm();
  }

  //Clear all contents at loading
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //INSERT
  insertUserRecord(form: NgForm) {
    console.log("Inserting a record...."); // For testing

    this.userService.addUser(form.value).subscribe(

      (result) => {
        console.log(result);
        this.toasterService.success('User Record Added successfully', 'Dating App');
        this.resetForm(form);
        this.router.navigate(['/hobby', this.userService.formData.UserId])

      }
    );
    //window.location.reload();
  }


  //UPDATE
  updateUserRecord(form: NgForm) {
    console.log("Updating a record...."); // For testing
    this.userService.updateUser(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetForm(form);
        this.toasterService.success('User Record updated successfully', 'Dating App');
        this.userService.bindListUsers();
        this.router.navigate(['hobby', this.userService.formData.UserId])

      }
    );
    //window.location.reload();
  }
}
