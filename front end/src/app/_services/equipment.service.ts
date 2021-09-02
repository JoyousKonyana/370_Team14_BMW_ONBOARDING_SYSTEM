import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Equipment} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllEquipment(): Observable<Equipment[]> {  
    return this.http.get<Equipment[]>(`${this.url}`);  
  }  

  getEquipmentById(id: string): Observable<Equipment> {  
      return this.http.get<Equipment>(`${this.url + '/GetEquipmentById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteEquipment/' + id}`);
  }

  update(id, equipment) {
    return this.http.put(`${this.url + '/UpdateEquipment/' + id}`, equipment);
  }

  create(equipment) {
    return this.http.post(`${this.url + '/CreateEquipment/'}`, equipment);
  }

} 