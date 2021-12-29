import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";
import {Lodger} from "@app/_models";
import { LodgerService } from '@app/_services';

@Component({
  selector: 'app-edit-lodger',
  templateUrl: './edit-lodger.component.html',
  styleUrls: ['./edit-lodger.component.css']
})
export class EditLodgerComponent implements OnInit {

  lodger: Lodger;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: LodgerService) { }

  ngOnInit() {
    let lodgerId = window.localStorage.getItem("editlodgerId");
    if(!lodgerId) {
      alert("Invalid action.")
      this.router.navigate(['list-lodger']);
      return;
    } 
    this.editForm = this.formBuilder.group({
      id: [''],
      name: ['', Validators.required],
      firstname: ['', Validators.required],
      gender: ['', Validators.required],
      civility: ['', Validators.required],
      adress: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      email:['', Validators.required],
      postalCode: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      birthday: ['', Validators.required],
      birthplace:['', Validators.required],
      nationalRegister:['', Validators.required]
    });
    this.apiService.getLodgerById(+lodgerId)
      .subscribe( data => {
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    console.log(this.editForm.get('phoneNumber').value);
    this.apiService.updateLodger(`?name=${this.editForm.get('name').value}&email=${this.editForm.get('email').value}&id=${this.editForm.get('id').value}&adress=${this.editForm.get('adress').value}&firstname=${this.editForm.get('firstname').value}&gender=${this.editForm.get('gender').value}&civility=${this.editForm.get('civility').value}&city=${this.editForm.get('city').value}&country=${this.editForm.get('country').value}&postalCode=${this.editForm.get('postalCode').value}&phoneNumber=${this.editForm.get('phoneNumber').value}&birthday=${this.editForm.get('birthday').value}&birthplace=${this.editForm.get('birthplace').value}&nationalRegister=${this.editForm.get('nationalRegister').value}`)
      .pipe(first())
      .subscribe(
        data => {
          if(data.status === 200) {
            alert('User updated successfully.');
            this.router.navigate(['list-lodger']);
          }else {
            alert('an item is incorrect ');
          }
        },
        error => {
          alert(error);
        });
  }
}