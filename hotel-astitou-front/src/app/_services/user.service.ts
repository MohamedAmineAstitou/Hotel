import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class UserService {
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User[]>(`${environment.apiUrl}/users`);
    }
    
      getUserById(id: number) {
        return this.http.get<User>(`${environment.apiUrl}/users/` + id);
      }
    
      createUser(user: String){
        return this.http.post<any>(`${environment.apiUrl}/users/register`+user,{});
      }
    
      updateUser(user: String) {
        return this.http.put<any>(`${environment.apiUrl}/users`+user,{});
      }
    
      deleteUser(id: number){
        return this.http.delete<any>(`${environment.apiUrl}/users/`+ id);
      }
}