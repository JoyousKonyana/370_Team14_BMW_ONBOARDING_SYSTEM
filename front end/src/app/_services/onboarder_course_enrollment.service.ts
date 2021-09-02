import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Onboarder_Course_Enrollment} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class Onboarder_Course_EnrollmentService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api';  

  constructor(private http: HttpClient) { }  

  getAllOnboarder_Course_Enrollment(): Observable<Onboarder_Course_Enrollment[]> {  
    return this.http.get<Onboarder_Course_Enrollment[]>(`${this.url}`);  
  }  

  getOnboarder_Course_EnrollmentById(id: string): Observable<Onboarder_Course_Enrollment> {  
      return this.http.get<Onboarder_Course_Enrollment>(`${this.url + '/GetOnboarder_Course_EnrollmentById/' + id}`);  
    }  

  delete(id: number) {
    return this.http.delete(`${this.url + '/DeleteOnboarder_Course_Enrollment/' + id}`);
  }

  update(id, onboarder_course_enrollment) {
    return this.http.put(`${this.url + '/UpdateOnboarder_Course_Enrollment/' + id}`, onboarder_course_enrollment);
  }

  create(course_onboarder_enrollment) {
    return this.http.post(`${this.url + '/CreateCourse_Onboarder_Enrollment/'}`, course_onboarder_enrollment);
  }

} 