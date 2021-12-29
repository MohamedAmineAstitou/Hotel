import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Apartment} from "@app/_models";
import { ApartmentService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-apartment',
  templateUrl: './list-apartment.component.html',
  styleUrls: ['./list-apartment.component.css'],
  
})
export class ListApartmentComponent implements OnInit {
  loading = false;
  apartments: Apartment[];
  test: string;

  constructor(private router: Router, private apiService: ApartmentService) { }

  ngOnInit() {
    this.loading = true;
    this.test="test";
    this.apiService.getAll().pipe(first()).subscribe(apartments => {
      this.loading = false;
        this.apartments = apartments;
      });
  }

  
  deleteApartment(apartment: Apartment): void {
    this.apiService.deleteApartment(apartment.id)
      .subscribe( data => {
        this.apartments = this.apartments.filter(l => l !== apartment);
      })
  };

  addBooking(apartment: Apartment): void {
    window.localStorage.removeItem("addbookingId");
    window.localStorage.setItem("addbookingId", apartment.id.toString());
    this.router.navigate(['add-booking']);
  };
  editApartment(apartment: Apartment): void {
    window.localStorage.removeItem("editApartmentId");
    window.localStorage.setItem("editApartmentId", apartment.id.toString());
    this.router.navigate(['edit-apartment']);
  };


  addApartment(): void {
    this.router.navigate(['add-apartment']);
  };
}