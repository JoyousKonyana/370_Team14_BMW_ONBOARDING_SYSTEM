
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Equipment_Query} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Equipment_QueryService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Faq';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllEquipment_Query(): Observable<Equipment_Query[]> {  
    return this.http.get<Equipment_Query[]>(`${this.url}`);  
  }  

  getEquipment_QueryById(id: string): Observable<Equipment_Query> {  
      return this.http.get<Equipment_Query>(`${this.url + '/GetEquipment_QueryById/' + id}`);  
    }

  create(x:Equipment_Query) {
    return this.http.post(`${this.url}/CreateEquipment_Query`, x, {headers:this.httHeaders});
  }

} 