import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {User_Role} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class User_RoleService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllUser_Role(): Observable<User_Role[]> {  
    return this.http.get<User_Role[]>(`${this.url}`);  
  }  

  getUser_RoleById(id: string): Observable<User_Role> {  
      return this.http.get<User_Role>(`${this.url + '/GetUser_RoleById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteUser_Role/' + id}`);
  }

  update(id, user_role) {
    return this.http.put(`${this.url + '/UpdateUser_Role/' + id}`, user_role);
  }

  create(user_role) {
    return this.http.post(`${this.url + '/CreateUser_Role/'}`, user_role);
  }

} 