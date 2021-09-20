import { UserRole } from './../_models/userrole';
import { Suburbs } from './../_models/suburbs';
import { Province } from './../_models/province';
import { PostalCode } from './../_models/postalCode';
import { Gender } from '@app/_models';
import { Department } from './../_models/department';
import { Country } from './../_models/country';
import { City } from './../_models/city';

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first, map } from 'rxjs/operators';

import { Reg_Emp, Title, Employee } from '../_models';
import { EmployeeService, AlertService, AuthenticationService } from '../_services';

import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RegisterEmployee } from '@app/_models/registerEmployeeDTO';


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
    alert('hello');
    this.loadAll();
}
m:City[]=[];
countries:Country[]=[];
departments :Department[] =[];
userrole: UserRole = {UserRoleId:1, UserRoleName:'',UserRoleAccessDescription:''};
useroles: UserRole[]=[];
postalcode: PostalCode[]=[];
provinces: Province[]=[];
mysuburb: Suburbs = {SuburbId:1, SuburbName:''};
suburbs: Suburbs [] =[];
mytitles: Title[]=[];
title: Title ={TitleId:1,TitleDescription:''};
myprovince: Province ={ ProvinceId:1, ProvinceName:''};
mypostalCode: PostalCode ={PostalCodeId:1,PostalCode1:''}
mygender:Gender ={GenderDescription:'', GenderId:1}
genders:Gender[]=[];
mydepartment:Department={depatmentId:0, departmentDescription:''}
mycountry: Country ={countryId:1,countryName:''};
c:City ={cityId:1,country: 'South africa'};
private loadAll() {
  this.employeeService.getInformationToRegister()
  .pipe(first())
  .subscribe(
    info => {
      this.info = info;
      console.log(this.info);
      
        info.cities.forEach(element => {
        this.c.cityId = element.cityId;
        this.c.country = element.country;
       
        this.m.push({cityId: this.c.cityId, country: this.c.country});
      });
      info.countries.forEach(element => {
        this.mycountry.countryId = element.countryId;
        this.mycountry.countryName = element.countryName;
        this.countries.push({countryId: element.countryId, countryName:element.countryName});
      });

      info.departments.forEach(element => {
        this.mydepartment.depatmentId = element.depatmentId;
        this.mydepartment.departmentDescription = element.departmentDescription;
        this.departments.push({depatmentId:this.mydepartment.depatmentId, departmentDescription:this.mydepartment.departmentDescription});
      });

      info.genders.forEach(element => {
        this.mygender.GenderId = element.genderId;
        this.mygender.GenderDescription = element.genderDescription;
        alert(this.mygender.GenderDescription);
        this.genders.push({ GenderId:this.mygender.GenderId, GenderDescription:this.mygender.GenderDescription});
        console.log(this.mygender)
     
      });
    

      info.postalCodes.forEach(element => {
        this.mypostalCode.PostalCodeId = element.postalCodeId;
        this.mypostalCode.PostalCode1 = element.postalCode1;
        this.postalcode.push({PostalCodeId:element.postalCodeId, PostalCode1:element.postalCode1 });
        this.genders.push(this.mygender);
      });

      info.provinces.forEach(element => {
        this.myprovince.ProvinceId = element.provinceId;
        this.myprovince.ProvinceName = element.provinceName;
        alert(element.postalCode1);
        this.provinces.push({ProvinceId: this.myprovince.ProvinceId, ProvinceName:  this.myprovince.ProvinceName });
      });

      info.suburbs.forEach(element => {
        this.mysuburb.SuburbId = element.suburbId;
        this.mysuburb.SuburbName = element.suburbName;
        this.suburbs.push({SuburbId:element.suburbId, SuburbName:element.suburbName });
      });

      info.titles.forEach(element => {
        this.title.TitleId = element.titleId;
        this.title.TitleDescription = element.titleDescription;
        this.mytitles.push({TitleId:this.title.TitleId, TitleDescription:  this.title.TitleDescription});
      });

      info.userRoles.forEach(element => {
        this.userrole.UserRoleId = element.userRoleId;
        this.userrole.UserRoleAccessDescription = element.userRoleDescription;
        this.userrole.UserRoleName =element.userRoleName
        this.useroles.push({UserRoleId:  this.userrole.UserRoleId, UserRoleAccessDescription:this.userrole.UserRoleAccessDescription,UserRoleName: this.userrole.UserRoleName});
      });




    
     
    
     
    },
    error => {
      this.alertService.error('Error, Data was unsuccesfully retrieved');
    } 
  );
}

  model2: RegisterEmployee = {
    
    DepartmentId: 1,
    UserRoleID: 1,
    GenderId: 1,
  
   
    FirstName: 'string',
    LastName: 'string',
    MiddleName: 'string',
    Idnumber: 1,
    EmailAddress: 'string',
    ContactNumber: 1,
    
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
  alert(this.model.first_name);
  this.model2.MiddleName = this.model.middle_name;
  this.model2.LastName = this.model.last_name;
  this.model2.Idnumber = this.model.id_number;
  this.model2.DepartmentId = this.model.department;
  this.model2.TitleId = this.model.job_title;
  this.model2.StreetNumber = this.model.street_number;
  this.model2.StreetName = this.model.street_name;
  // this.model2.EmailAddress= this.model.emailAdress;
  // this.model2.ContactNumber = this.model.contact_number;
  // this.model.UserRoleID = this.model.user_role;

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