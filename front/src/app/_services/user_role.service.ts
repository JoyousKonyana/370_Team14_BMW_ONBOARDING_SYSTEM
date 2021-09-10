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
   url = 'https://localhost:44319/api/UserRoleController';  

  constructor(private http: HttpClient) { }  

  getAllUser_Role(): Observable<User_Role[]> {  
    return this.http.get<User_Role[]>(`${this.url}`);  
  }  

  getUser_RoleById(id: string): Observable<User_Role> {  
      return this.http.get<User_Role>(`${this.url + '/GetUser_RoleById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteUserRole/`+id);
  }

  update(id: number, user_role:User_Role) {
    return this.http.put(`${this.url}/UpdateUserRole`, user_role);
  }

  create(user_role: User_Role) {
    return this.http.post(`${this.url}/CreateUserRole`, user_role);
  }

} 