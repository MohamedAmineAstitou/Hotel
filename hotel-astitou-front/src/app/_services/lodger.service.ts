import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Lodger } from '@app/_models';
import { environment } from '@environments/environment';
@Injectable({
  providedIn: 'root'
})
export class LodgerService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Lodger[]>(`${environment.apiUrl}/lodgers`);
  }
  
    getLodgerById(id: number) {
      return this.http.get<Lodger>(`${environment.apiUrl}/lodgers/` + id);
    }
  
    createLodger(lodger: String){
      return this.http.post<any>(`${environment.apiUrl}/lodgers/CreateLodger`+lodger,{});
    }
  
    updateLodger(lodger: String) {
      return this.http.put<any>(`${environment.apiUrl}/lodgers`+lodger,{});
    }
  
    deleteLodger(id: number){
      return this.http.delete<any>(`${environment.apiUrl}/lodgers/`+ id);
    }
}
