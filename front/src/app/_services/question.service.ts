
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Question} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Question';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getAllQuestion(): Observable<Question[]> {  
    return this.http.get<Question[]>(`${this.url}/GetAllQuestions`);  
  }  

  getQuestionById(id: number): Observable<Question> {  
      return this.http.get<Question>(`${this.url}/GetQuestionsById/`+id);  
    }  

    getQuestionsforQuiz(id: number): Observable<Question[]> {  
      return this.http.get<Question[]>(`${this.url}/GetQuestionsForQuiz/`+id);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteQuestion/`+ id);
  }

  update(id:number, question:Question) {
    return this.http.put(`${this.url}/UpdateQuestion/`+ id, question);
  }

  create(question:Question) {
    return this.http.post(`${this.url}/CreateQuestion`, question, {headers:this.httHeaders});
  }

} 