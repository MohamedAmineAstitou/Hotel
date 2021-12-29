import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Apartment } from '@app/_models';
import { environment } from '@environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ApartmentService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Apartment[]>(`${environment.apiUrl}/apartments`);
  }
  
    getApartmentById(id: number) {
      return this.http.get<Apartment>(`${environment.apiUrl}/apartments/` + id);
    }
  
    createApartment(apartment: String){
      return this.http.post<any>(`${environment.apiUrl}/apartments/CreateApartment`+apartment,{});
    }
  
    updateApartment(apartment: String) {
      return this.http.put<any>(`${environment.apiUrl}/apartments`+apartment,{});
    }
  
    deleteApartment(id: number){
      return this.http.delete<any>(`${environment.apiUrl}/apartments/`+ id);
    }
}
