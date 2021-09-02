import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Learning_Outcome} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Learning_OutcomeService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllLearning_Outcome(): Observable<Learning_Outcome[]> {  
    return this.http.get<Learning_Outcome[]>(`${this.url}`);  
  }  

  getLearning_OutcomeById(id: string): Observable<Learning_Outcome> {  
      return this.http.get<Learning_Outcome>(`${this.url + '/GetLearning_OutcomeById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteLearning_Outcome/' + id}`);
  }

  update(id, learning_outcome) {
    return this.http.put(`${this.url + '/UpdateLearning_Outcome/' + id}`, learning_outcome);
  }

  create(learning_outcome) {
    return this.http.post(`${this.url + '/CreateLearning_Outcome/'}`, learning_outcome);
  }

} 