import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Onboarder} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class OnboarderService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllOnboarder(): Observable<Onboarder[]> {  
    return this.http.get<Onboarder[]>(`${this.url}`);  
  }  

  getOnboarderById(id: string): Observable<Onboarder> {  
      return this.http.get<Onboarder>(`${this.url + '/GetOnboarderById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteOnboarder/' + id}`);
  }

  update(id, onboarder) {
    return this.http.put(`${this.url + '/UpdateOnboarder/' + id}`, onboarder);
  }

  create(onboarder) {
    return this.http.post(`${this.url + '/CreateOnboarder/'}`, onboarder);
  }

} 