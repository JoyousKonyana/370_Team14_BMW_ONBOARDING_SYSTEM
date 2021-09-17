import { City } from './../_models/city';

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first, map } from 'rxjs/operators';

import { Reg_Emp, Title, Employee } from '../_models';
import { EmployeeService, AlertService, AuthenticationService } from '../_services';

import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({ 
    templateUrl: 'register_employee.component.html',
    styleUrls: ['./ss_administrator.component.css']
})
export class Register_EmployeeComponent implements OnInit {

  employee: Reg_Emp[] = [];

  info: any[];
  citiese:any[];
  myCity:City;

  constructor(
      
      private alertService: AlertService,

      private employeeService: EmployeeService,
  ) {
  }

  ngOnInit() { 
    this.loadAll();
}
m:City;
private loadAll() {
  this.employeeService.getInformationToRegister()
  .pipe(first())
  .subscribe(
    info => {
      this.info = info;
     
    
     
    },
    error => {
      this.alertService.error('Error, Data was unsuccesfully retrieved');
    } 
  );
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

  titles(index) {
    this.model2.TitleId = index;
  }

  gender(index) {
    this.model2.GenderId = index;
  }

  department(index) {
    this.model2.DepartmentId = index;
  }

  user_role(index) {
    this.model2.UserRoleID = index;
  }

  suburb(index) {
    this.model2.SuburbId = index;
  }

  province(index) {
    this.model2.ProvinceId = index;
  }

  city(index) {
    this.model2.CityId = index;
  }

  country(index) {
    this.model2.CountryId = index;
  }

 addEmployee() { 
    
  this.model2.FirstName = this.model.first_name;
  this.model2.MiddleName = this.model.middle_name;
  this.model2.LastName = this.model.last_name;
  this.model2.Idnumber = this.model.id_number;
  this.model2.DepartmentId = this.model.department;
  this.model2.TitleId = this.model.job_title;
  this.model2.StreetNumber = this.model.street_number;
  this.model2.StreetName = this.model.street_name;

     if(Object.keys(this.model).length < 2)
     {
      
       this.alertService.error("Error, you have an empty feild");
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