import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Booking } from '@app/_models';
import { environment } from '@environments/environment';
@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Booking[]>(`${environment.apiUrl}/bookings`);
  }
  
    getBookingById(id: number) {
      return this.http.get<Booking>(`${environment.apiUrl}/bookings/` + id);
    }
  
    createBooking(booking: String){
      return this.http.post<any>(`${environment.apiUrl}/bookings/CreateBooking`+booking,{});
    }
  
    updateBooking(booking: String) {
      return this.http.put<any>(`${environment.apiUrl}/bookings`+booking,{});
    }
  
    deleteBooking(id: number){
      return this.http.delete<any>(`${environment.apiUrl}/bookings/`+ id);
    }
}
