import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Lesson_Content} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Lesson_ContentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/LessonContent';  

  constructor(private http: HttpClient) { }  

  getAllLesson_Content(): Observable<Lesson_Content[]> {  
    return this.http.get<Lesson_Content[]>(`${this.url}/`);  
  }  

  getLesson_ContentById(id: string): Observable<Lesson_Content> {  
      return this.http.get<Lesson_Content>(`${this.url + '/GetLesson_ContentById/' + id}`);  
    }  

    getLesson_ContentByLessonoutcomeId(id: string): Observable<Lesson_Content> {  
      return this.http.get<Lesson_Content>(`${this.url}/GetLessonContentByLessonOutcome/`+id);  
    } 

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteLessonContent/`+id);
  }

  update(id, lesson_content) {
    return this.http.put(`${this.url}/UpdateLessonContent`+ id, lesson_content);
  }

  create(lesson_content) {
    return this.http.post(`${this.url}/UploadContentLink`, lesson_content);
  }


  AchiveLessonContent(id: number, lessoncontent:Lesson_Content) {
    return this.http.put(`${this.url}/AchiveLessonContent/`+id,lessoncontent);
  }

} 