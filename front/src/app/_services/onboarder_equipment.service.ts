import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Onboarder_Equipment} from '@app/_models';
import { AssignEquipment } from '@app/_models/assigequipment';

@Injectable({
  providedIn: 'root'
})
export class Onboarder_EquipmentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllOnboarder_Equipment(): Observable<Onboarder_Equipment[]> {  
    return this.http.get<Onboarder_Equipment[]>(`${this.url}`);  
  }  

  getOnboarder_EquipmentById(id: string): Observable<Onboarder_Equipment> {  
      return this.http.get<Onboarder_Equipment>(`${this.url + '/GetOnboarder_EquipmentById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteOnboarder_Equipment/' + id}`);
  }

  update(id, onboarder_equipment) {
    return this.http.put(`${this.url + '/UpdateOnboarder_Equipment/' + id}`, onboarder_equipment);
  }

  create(onboarder_equipment:AssignEquipment) {
    return this.http.post(`${this.url}/AssignedEquipment`, onboarder_equipment);
  }

  AssignEquipment(assignedEquipment:AssignEquipment[]){
    return this.http.post(`${this.url}/AssignedEquipment2`,assignedEquipment);
  }
  GetAssignedEquipment(id: number){
    return this.http.get(`${this.url}/GetAssignedEquipment`+ id);
  }
} 