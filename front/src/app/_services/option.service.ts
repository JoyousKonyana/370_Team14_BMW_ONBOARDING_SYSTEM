import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Option} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class OptionService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Faq';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllOption(): Observable<Option[]> {  
    return this.http.get<Option[]>(`${this.url}`);  
  }  

  getOptionById(id: string): Observable<Option> {  
      return this.http.get<Option>(`${this.url + '/GetOptionById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteOption/' + id}`);
  }

  update(id, option) {
    return this.http.put(`${this.url + '/UpdateOption/' + id}`, option);
  }

  create(option:Option) {
    return this.http.post(`${this.url}/CreateFAQ`, option, {headers:this.httHeaders});
  }

} 