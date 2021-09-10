import { CheckOut } from './../_models/checkoutModel';
import { ReportsModel } from './../_models/reportModel';
import { EquipmentQuery } from './../_models/equipmentquery';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Equipment, AssignEquipment} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Equipment';  

  constructor(private http: HttpClient) { }  

  getAllEquipment(): Observable<Equipment[]> {  
    return this.http.get<Equipment[]>(`${this.url}`);  
  }  

  getEquipmentById(id: string): Observable<Equipment> {  
      return this.http.get<Equipment>(`${this.url + '/GetEquipmentById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteEquipment/`+ id);
  }

  update(id:number, equipment:Equipment) {
    return this.http.put(`${this.url}/UpdateEquipment`+ id, equipment);
  }

  create(equipment) {
    return this.http.post(`${this.url}/RegisterEquipment`,equipment);
  }

  AssignEquipment(assignedEquipment:AssignEquipment){
    return this.http.post(`${this.url}/AssignedEquipment`,assignedEquipment);
  }
  //used by onboarder
  GetAssignedEquipment(id: number){
    return this.http.get(`${this.url}/GetAssignedEquipment/`+ id);
  }
  
  ReportEquipmentQuery(equipmentQuery:EquipmentQuery){
    return this.http.post(`${this.url}/ReportEquipmentQuery`,equipmentQuery);
  }

  generateEquipmentReport(reportdata: ReportsModel){
    return this.http.post(`${this.url}/GenerateEquipmentReport`,reportdata);
  }
  
  generateTradeInReport(reportdata: ReportsModel){
    return this.http.post(`${this.url}/GenerateTradeInReport`,reportdata);
  }
  checkoutEquipment(equipcheckout:CheckOut){
    return this.http.put(`${this.url}/EquipmentDueForTradeIn`,equipcheckout);
  }

} 