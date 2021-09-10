import { AssignCourse } from './../_models/assigncourse';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Course} from '@app/_models';
import * as _models from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Course';  

  constructor(private http: HttpClient) { }  

  getAllCourse(): Observable<any> {  
    return this.http.get<any>(`${this.url}/GetAllCourses`);  
  }  

  getCourseById(id: number): Observable<Course> {  
      return this.http.get<Course>(`${this.url}/GetCourseById/`+ id);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url}/DeleteCourse/`+ id);
  }

  update(id: number, course: Course) {
    return this.http.put(`${this.url}/UpdateCourse`+ id, course);
  }

  create(course) {
    return this.http.post(`${this.url}/CreateCourse`, course);
  }
 
 assigne(assign: AssignCourse[]){
   return this.http.post(`${this.url}/CreateCourse/AssignCourse`, assign);
 }

} 