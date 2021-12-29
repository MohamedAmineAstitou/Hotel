import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {first} from "rxjs/operators";
import {Apartment} from "@app/_models";
import { ApartmentService } from '@app/_services';

@Component({
  selector: 'app-edit-apartment',
  templateUrl: './edit-apartment.component.html',
  styleUrls: ['./edit-apartment.component.css']
})
export class EditApartmentComponent implements OnInit {

  apartment: Apartment;
  editForm: FormGroup;
  constructor(private formBuilder: FormBuilder,private router: Router, private apiService: ApartmentService) { }

  ngOnInit() {
    let apartmentId = window.localStorage.getItem("editApartmentId");
    if(!apartmentId) {
      alert("Invalid action.")
      this.router.navigate(['list-apartment']);
      return;
    }
    this.editForm = this.formBuilder.group({
      id: [''],
      adress: ['', Validators.required],
      type: ['', Validators.required],
      floor: ['', Validators.required],
      roomNumber: ['', Validators.required],
      totalArea: ['', Validators.required],
      bedroomArea: ['', Validators.required],
      diningArea: ['', Validators.required],
      rentPrice:['', Validators.required]
    });
    this.apiService.getApartmentById(+apartmentId)
      .subscribe( data => {
        this.editForm.setValue(data);
      });
  }

  onSubmit() {
    console.log(this.editForm.get('id').value);
    this.apiService.updateApartment(`?adress=${this.editForm.get('adress').value}&type=${this.editForm.get('type').value}&id=${this.editForm.get('id').value}&floor=${this.editForm.get('floor').value}&roomNumber=${this.editForm.get('roomNumber').value}&totalArea=${this.editForm.get('totalArea').value}&bedroomArea=${this.editForm.get('bedroomArea').value}&diningArea=${this.editForm.get('diningArea').value}&rentPrice=${this.editForm.get('rentPrice').value}`)
      .pipe(first())
      .subscribe(
        data => {
          if(data.status === 200) {
            alert('User updated successfully.');
            this.router.navigate(['list-apartment']);
          }else {
            alert('an item is incorrect ');
          }
        },
        error => {
          alert(error);
        });
  }

}