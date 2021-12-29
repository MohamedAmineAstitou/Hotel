import { Component, OnInit , Inject} from '@angular/core';
import {Router} from "@angular/router";
import {Booking} from "@app/_models";
import { BookingService } from '@app/_services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-list-booking',
  templateUrl: './list-booking.component.html',
  styleUrls: ['./list-booking.component.css'],
  
})
export class ListBookingComponent implements OnInit {
  loading = false;
  bookings: Booking[];
  test: string;

  constructor(private router: Router, private apiService: BookingService) { }

  ngOnInit() {
    this.loading = true;
    this.test="test";
    this.apiService.getAll().pipe(first()).subscribe(bookings => {
      this.loading = false;
        this.bookings = bookings;
      });
  }

  
  deleteBooking(booking: Booking): void {
    this.apiService.deleteBooking(booking.id)
      .subscribe( data => {
        this.bookings = this.bookings.filter(l => l !== booking);
      })
  };

  editBooking(booking: Booking): void {
    window.localStorage.removeItem("editBookingtId");
    window.localStorage.setItem("editBookingtId", booking.id.toString());
    this.router.navigate(['edit-booking']);
  };
}