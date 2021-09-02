
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

import {Certificate} from '@app/_models';

@Injectable({
  providedIn: 'root'
})
export class CertificateService {

   //Joyous, please put the link of the API here
   url = 'https://localhost:44319/api/Faq';  
  //  header= new HttpHeaders(){
  //   // Content-Type: "application/json"
  //  };

  httHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private http: HttpClient) { }  

  getCertificateById(id: string): Observable<Certificate> {  
      return this.http.get<Certificate>(`${this.url + '/GetCertificateById/' + id}`);  
    } 

} 