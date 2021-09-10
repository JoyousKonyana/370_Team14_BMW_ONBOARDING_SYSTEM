import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Reg_Emp } from '../_models';
import { EmployeeService, AlertService, AuthenticationService } from '../_services';

import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({ 
    templateUrl: 'register_employee.component.html',
    styleUrls: ['./ss_administrator.component.css']
})
export class Register_EmployeeComponent implements OnInit {
  dataSaved = false;  
  employeeForm: any;

  employee: Reg_Emp[] = [];

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

  model2: Reg_Emp = {
    EmployeeId: 1,
    DepartmentId: 1,
    UserRoleID: 1,
    GenderId: 1,
    AddressId: 1,
    EmployeeCalendarId: '',
    FirstName: 'string',
    LastName: 'string',
    MiddleName: 'string',
    Idnumber: 1,
    EmailAddress: 'string',
    ContactNumber: '1',
    EmployeeJobTitle: 'vhv',
    TitleId: 1,
    SuburbId: 1,
    ProvinceId: 1,
    CityId: 1,
    CountryId: 1,
    StreetNumber: 1,
    StreetName: 'string'
};
  model: any = {}; 

 addEmployee() { 
    
  this.model2.FirstName = this.model.LastName;
  this.model2.MiddleName = this.model.middle_name;
  this.model2.LastName = this.model.last_name;
  this.model2.TitleId = this.model.title;
  this.model2.GenderId = this.model.gender;
  this.model2.Idnumber = this.model.id_number;
  this.model2.DepartmentId = this.model.department;
  this.model2.TitleId = this.model.job_title;
  this.model2.AddressId = this.model.address;


     if(Object.keys(this.model).length < 2)
     {
      
       this.alertService.error("Error, you have an empty feild");
  //     console.log('Empty');
     }
     else if((Object.keys(this.model).length>=2))
     {
       this.employeeService.create(this.model2)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Registration was successful', true);
                },
                 error => {
                     this.alertService.error('Error, Registration was unsuccesful');
                 });
     }
   }

  myValue;
    
}