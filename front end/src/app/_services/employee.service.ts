import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Employee} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllEmployee(): Observable<Employee[]> {  
    return this.http.get<Employee[]>(`${this.url}`);  
  }  

  getEmployeeById(id: string): Observable<Employee> {  
      return this.http.get<Employee>(`${this.url + '/GetByEmployeeId/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteEmployee/' + id}`);
  }

  update(id, employee) {
    return this.http.put(`${this.url + '/UpdateEmployee/' + id}`, employee);
  }

  create(employee) {
    return this.http.post(`${this.url + '/RegisterEquipment/'}`, employee);
  }

} 