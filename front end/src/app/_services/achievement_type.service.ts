

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Achievment_Type} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Achievment_TypeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Faq';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllAchievment_Type(): Observable<Achievment_Type[]> {  
    return this.http.get<Achievment_Type[]>(`${this.url}`);  
  }  

  getAchievment_TypeById(id: string): Observable<Achievment_Type> {  
      return this.http.get<Achievment_Type>(`${this.url + '/GetAchievment_TypeById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteAchievment_Type/' + id}`);
  }

  update(id, achievment_type) {
    return this.http.put(`${this.url + '/UpdateAchievment_Type/' + id}`, achievment_type);
  }

  create(achievment_type:Achievment_Type) {
    return this.http.post(`${this.url}/CreateAchievment_Type`, achievment_type, {headers:this.httHeaders});
  }

} 