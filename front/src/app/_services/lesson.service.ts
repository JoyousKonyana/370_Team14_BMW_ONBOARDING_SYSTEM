import { Lesson } from './../_models/lesson';
import { Lesson_Content } from '@app/_models';
import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class LessonService {
  url = 'https://localhost:44319/api/Lesson';  

  constructor(private http: HttpClient) { }  

  getAllLessons(): Observable<Lesson[]> {  
    return this.http.get<Lesson[]>(`${this.url}/GetAllLessons`);  
  }  

  getLessonById(id: number): Observable<Lesson> {  
      return this.http.get<Lesson>(`${this.url}/GetLessonById/`+id);  
    }  

    getLesson_ContentByLessonoutcomeId(id: string): Observable<Lesson_Content> {  
      return this.http.get<Lesson_Content>(`${this.url}/GetLessonContentByLessonOutcome/`+id);  
    } 

    getLessonByCourseId(id: number): Observable<Lesson> {  
      return this.http.get<Lesson>(`${this.url}/GetLessonByCourseId`+id);  
    } 

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteLesson/`+id);
  }

  update(id, lesson) {
    return this.http.put(`${this.url}/UpdateLesson`+ id, lesson);
  }

  create(lesson) {
    return this.http.post(`${this.url}/CreateLesson`, lesson);
  }


}
