import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guarantor } from '@app/_models';
import { environment } from '@environments/environment';
@Injectable({
  providedIn: 'root'
})
export class GuarantorService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Guarantor[]>(`${environment.apiUrl}/guarantor`);
  }
  
    getGuarantorById(id: number) {
      return this.http.get<Guarantor>(`${environment.apiUrl}/guarantor/` + id);
    }
  
    createGuarantor(guarantor: String){
      return this.http.post<any>(`${environment.apiUrl}/guarantor`+guarantor,{});
    }
  
    updateGuarantor(guarantor: String) {
      return this.http.put<any>(`${environment.apiUrl}/guarantor`+guarantor,{});
    }
  
    deleteGuarantor(id: number){
      return this.http.delete<any>(`${environment.apiUrl}/guarantor/`+ id);
    }
}
