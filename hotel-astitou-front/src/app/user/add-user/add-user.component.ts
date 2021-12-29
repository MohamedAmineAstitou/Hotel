import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import { UserService } from '@app/_services';


@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: UserService) { }

  addForm: FormGroup;

  ngOnInit() {
    this.addForm = this.formBuilder.group({
      id: [],
      username: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required],
    });

  }
  onSubmit() {
    console.log(this.addForm.get('username').value);
    console.log(this.addForm.get('password').value);
    console.log(this.addForm.get('email').value);
    this.apiService.createUser(`?username=${this.addForm.get('username').value}&password=${this.addForm.get('password').value}&email=${this.addForm.get('email').value}`)
      .subscribe( data => {
        this.router.navigate(['list-user']);
      });
  }

}
