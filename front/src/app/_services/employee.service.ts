import { RegisterEmployee } from './../_models/registerEmployeeDTO';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Reg_Emp, Employee, Title, Gender} from '@app/_models';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Employee';  
   titleurl = 'https://localhost:44319/api/Title'; 

  constructor(private http: HttpClient) { }  

  //this return an object containing all the required information
  // before you can register
  getInformationToRegister(){
    return this.http.get<any>(`${this.url}/GetAll`);
  }
  getAllEmployee(): Observable<any> {  
    return this.http.get<any>(`${this.url}/GetAllEmployees`);  
  }  

  getEmployeeById(id: number): Observable<Employee> {  
    return this.http.get<Employee>(`${this.url}/GetEmployeeById`+ id);  
  }  

  getAllGender(): Observable<any> {
    return this.http.get<any>(`${this.url}/GetAllGender`);
  }

  delete(id: number) {
    return this.http.delete(`${this.url}/`+ id);
  }

  update(id, employee:Reg_Emp) {
    return this.http.put(`${this.url}/UpdateEmployee/`+ id, employee);
  }

  create(reg_emp: Reg_Emp) {
     return this.http.post(`${this.url}/RegisterEmployee/`, reg_emp);
  }

  RegisterEmployeeFromImport(newEmployees:RegisterEmployee[]){
    return this.http.post(`${this.url}/RegisterEmployeesFromImport`, newEmployees);
  }

} 