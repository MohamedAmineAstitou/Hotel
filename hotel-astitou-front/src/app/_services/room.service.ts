import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Room } from '@app/_models';
import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  constructor(private http: HttpClient) { }

  getAll() {
      return this.http.get<Room[]>(`${environment.apiUrl}/rooms`);
  }
  
    getRoomById(id: number) {
      return this.http.get<Room>(`${environment.apiUrl}/rooms/` + id);
    }
  
    createRoom(room: String){
      return this.http.post<any>(`${environment.apiUrl}/rooms`+room,{});
    }
  
    updateRoom(room: String) {
      return this.http.put<any>(`${environment.apiUrl}/rooms`+room,{});
    }
  
    deleteRoom(id: number){
      return this.http.delete<any>(`${environment.apiUrl}/rooms/`+ id);
    }
}
