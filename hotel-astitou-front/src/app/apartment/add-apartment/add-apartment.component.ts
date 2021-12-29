import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import { ApartmentService } from '@app/_services';


@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.css']
})
export class AddApartmentComponent implements OnInit {

  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: ApartmentService) { }

  addForm: FormGroup;

  ngOnInit() {
    this.addForm = this.formBuilder.group({
      adress: ['', Validators.required],
      type: ['', Validators.required],
      totalArea: ['', Validators.required],
      floor: ['', Validators.required],
      roomNumber: ['', Validators.required],
      bedroomArea: ['', Validators.required],
      diningArea: ['', Validators.required],
      rentPrice: ['', Validators.required],
    });

  }
  onSubmit() {
    console.log(this.addForm.get('adress').value);
    console.log(this.addForm.get('type').value);
    console.log(this.addForm.get('totalArea').value);
    console.log(this.addForm.get('roomNumber').value);
    console.log(this.addForm.get('floor').value);
    console.log(this.addForm.get('bedroomArea').value);
    console.log(this.addForm.get('diningArea').value);
    console.log(this.addForm.get('rentPrice').value);

    this.apiService.createApartment(`?adress=${this.addForm.get('adress').value}&type=${this.addForm.get('type').value}}&floor=${this.addForm.get('floor').value}&roomNumber=${this.addForm.get('roomNumber').value}&totalArea=${this.addForm.get('totalArea').value}&bedroomArea=${this.addForm.get('bedroomArea').value}&diningArea=${this.addForm.get('diningArea').value}&rentPrice=${this.addForm.get('rentPrice').value}`)
      .subscribe( data => {
        this.router.navigate(['list-apartment']);
      });
  }

}
