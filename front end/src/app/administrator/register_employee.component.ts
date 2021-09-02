import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Employee } from '../_models';
import { EmployeeService, AlertService, AuthenticationService } from '../_services';

import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({ 
    templateUrl: 'register_employee.component.html',
    styleUrls: ['./ss_administrator.component.css']
})
export class Register_EmployeeComponent implements OnInit {
  dataSaved = false;  
  employeeForm: any;

  employee: Employee[] = [];

  filtered: Object[]

  employeeIdUpdate = null;  
  massage = null;

  constructor(
      
      private alertService: AlertService,

      private employeeService: EmployeeService,
  ) {
  }

  ngOnInit() { 
  }

  model: any = {};
  model2: any = {}; 

 addEmployee() { 
     if(Object.keys(this.model).length < 2)
     {
       this.alertService.error("Error, you have an empty feild");
  //     console.log('Empty');
       this.model = {};
     }
     else if((Object.keys(this.model).length==2))
     {
       this.employeeService.create(this.model)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Registration was successful', true);
                     this.employee.push(this.model);
                     this.model = {};
                },
                 error => {
                     this.alertService.error('Error, Registration was unsuccesful');
                    
                     this.employee.push(this.model);//Please Remove this When the you have connected to the API
                     this.model = {};
                 });
     }
   }

  myValue;
    
}