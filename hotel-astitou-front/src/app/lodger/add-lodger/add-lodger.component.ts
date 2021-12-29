import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import { LodgerService } from '@app/_services';
import { GuarantorService } from '@app/_services';


@Component({
  selector: 'app-add-lodger',
  templateUrl: './add-lodger.component.html',
  styleUrls: ['./add-lodger.component.css']
})
export class AddLodgerComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: LodgerService, private guarantorService: GuarantorService ) { }

  addForm: FormGroup;

  ngOnInit() {
    this.addForm = this.formBuilder.group({
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

  }
  onSubmit() {
 
console.log(this.addForm.get('name').value);

    this.apiService.createLodger(`?name=${this.addForm.get('name').value}&email=${this.addForm.get('email').value}&id=${this.addForm.get('id').value}&adress=${this.addForm.get('adress').value}&firstname=${this.addForm.get('firstname').value}&gender=${this.addForm.get('gender').value}&civility=${this.addForm.get('civility').value}&city=${this.addForm.get('city').value}&country=${this.addForm.get('country').value}&postalCode=${this.addForm.get('postalCode').value}&phoneNumber=${this.addForm.get('phoneNumber').value}&birthday=${this.addForm.get('birthday').value}&birthplace=${this.addForm.get('birthplace').value}&nationalRegister=${this.addForm.get('nationalRegister').value}`)
    .subscribe( data => {
      this.router.navigate(['list-lodger']);
    });
     
  }

}
