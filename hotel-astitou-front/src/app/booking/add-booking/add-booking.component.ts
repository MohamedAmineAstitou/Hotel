import { Component, OnInit, Inject } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first } from "rxjs/operators";
import { Booking } from "@app/_models";
import { Apartment } from "@app/_models";
import { BookingService } from '@app/_services';

@Component({
  selector: 'app-add-booking',
  templateUrl: './add-booking.component.html',
  styleUrls: ['./add-booking.component.css']
})
export class AddBookingComponent implements OnInit {
  appartment:Apartment;
  booking: Booking;
  addForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, private apiService: BookingService) { }

  ngOnInit() {
    let apartmentId = window.localStorage.getItem("addbookingId");
    if (!apartmentId) {
      alert("Invalid action.")
      this.router.navigate(['list-apartment']);
      return;
    }
    this.addForm = this.formBuilder.group({
      id: [''],
      dateOfArrival: ['', Validators.required],
      dateOfDeparture: ['', Validators.required],
      lodgerId: ['', Validators.required]
    });
  }

  onSubmit() {
    console.log(window.localStorage.getItem("addbookingId"));
    console.log(this.addForm.get('dateOfArrival').value);
    console.log(this.addForm.get('dateOfDeparture').value);
    console.log(this.addForm.get('lodgerId').value);
    this.apiService.createBooking(`?dateOfArrival=${this.addForm.get('dateOfArrival').value}&dateOfDeparture=${this.addForm.get('dateOfDeparture').value}&lodgerId=${this.addForm.get('lodgerId').value}&idApartment=${window.localStorage.getItem("addbookingId")}`)
      .subscribe(data => {
        this.router.navigate(['list-booking']);
      });
  }
}

