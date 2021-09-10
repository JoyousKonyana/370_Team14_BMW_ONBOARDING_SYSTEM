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
   url = 'https://localhost:44319/api/LessonOutcome';  

  constructor(private http: HttpClient) { }  

  getAllLearning_Outcome(): Observable<Learning_Outcome[]> {  
    return this.http.get<Learning_Outcome[]>(`${this.url}/GetAllLessonOutcomes`);  
  }  

  getLearning_OutcomeById(id: number): Observable<Learning_Outcome> {  
      return this.http.get<Learning_Outcome>(`${this.url}/GeLessonOutcomeByLessonId/`+id);  
    }  

    getLearning_OutcomeByLessonID(id: number): Observable<Learning_Outcome> {  
      return this.http.get<Learning_Outcome>(`${this.url}/GeLessonOutcomeByLessonId/`+id);  
    } 

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteLessonOutcome/`+id);
  }

  update(id: number, learning_outcome: Learning_Outcome) {
    return this.http.put(`${this.url}/UpdateLessonOutcome/`+ id, learning_outcome);
  }

  create(learning_outcome: Learning_Outcome) {
    return this.http.post(`${this.url}/CreateLessonOutcome`, learning_outcome);
  }

 


} 