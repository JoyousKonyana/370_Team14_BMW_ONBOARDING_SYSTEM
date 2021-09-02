import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Query_Status} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Query_StatusService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Faq';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { } 

  getQuery_StatusById(id: string): Observable<Query_Status> {  
      return this.http.get<Query_Status>(`${this.url + '/GetQuery_StatusById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteQuery_Status/' + id}`);
  }

  update(id, query_status) {
    return this.http.put(`${this.url + '/UpdateQuery_Status/' + id}`, query_status);
  }

  create(query_status:Query_Status) {
    return this.http.post(`${this.url}/CreateQuery_Status`, query_status, {headers:this.httHeaders});
  }

} 