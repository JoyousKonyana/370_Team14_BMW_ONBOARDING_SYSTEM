import { ResolveQuery } from './../_models/resolvequery';

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Equipment_Query} from '@app/_models';
import { EquipmentQuery } from '@app/_models/equipmentquery';

@Injectable({
  providedIn: 'root'
})
export class Equipment_QueryService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/EquipmentQuery';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllEquipment_Query(): Observable<Equipment_Query[]> {  
    return this.http.get<Equipment_Query[]>(`${this.url}/GetAllQueries`);  
  }  

  getEquipment_QueryById(id: number): Observable<Equipment_Query> {  
      return this.http.get<Equipment_Query>(`${this.url}/GetQuerybyid/` +id);  
    }

  create(x:EquipmentQuery) {
    return this.http.post(`${this.url}/ReportEquipmentQuery`, x, {headers:this.httHeaders});
  }
  resolveQuery(resolve: ResolveQuery){
    return this.http.put(`${this.url}/ResolveQuery`, resolve);
  }

} 