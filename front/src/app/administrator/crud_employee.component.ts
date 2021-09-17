import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';


import { Employee, Reg_Emp } from '../_models';
import { EmployeeService, AuthenticationService, AlertService } from '../_services';



@Component({ 
    templateUrl: 'crud_employee.component.html',
    styleUrls: ['./ss_administrator.component.css'] 
})

export class CRUD_EmployeeComponent implements OnInit {
  employee: Employee[] = [];
  info: Reg_Emp[] = [];

  constructor(
      private employeeService: EmployeeService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
    this.loadAll();
}

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

  this.employeeService.getAllEmployee()
  .pipe(first())
  .subscribe(
    employee => {
      this.employee = employee;
    },
    error => {
      this.alertService.error('Error, Data was unsuccesfully retrieved');
    } 
  );
}

  updateEmployeeClicked = false;

  color;

  model: any = {};
  
  deleteEmployee(i) {
    this.employeeService.delete(i+1)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);
                    this.employee.splice(i, 1);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                });
  }

  myValue;

  editEmployee(editEmployeeInfo) {
    this.updateEmployeeBtn();

    this.model.first_name = this.employee[editEmployeeInfo].first_name;
    this.model.Middle_Name = this.employee[editEmployeeInfo].Middle_Name;
    this.model.Last_Name = this.employee[editEmployeeInfo].Last_Name;
    this.model.ID_Number = this.employee[editEmployeeInfo].ID_Number;
    this.model.Contact_Number = this.employee[editEmployeeInfo].Contact_Number;
    this.model.Job_Title = this.employee[editEmployeeInfo].Job_Title;
    this.myValue = editEmployeeInfo;
  }

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
    
  updateEmployee() {
    let editEmployeeInfo = this.myValue;

    this.model2.FirstName = this.model.first_name;
    this.model2.MiddleName = this.model.middle_name;
    this.model2.LastName = this.model.last_name;
    this.model2.Idnumber = this.model.id_number;
    this.model2.DepartmentId = this.model.department;
    this.model2.TitleId = this.model.job_title;
    this.model2.StreetNumber = this.model.street_number;
    this.model2.StreetName = this.model.street_name;

    for(let i = 0; i < this.employee.length; i++) {

      if(i == editEmployeeInfo) 
      {
        this.employeeService.update(editEmployeeInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);
                    this.loadAll();
                    this.model = {};
                    this.updateEmployeeBtn();
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                    this.updateEmployeeBtn();
                });
      }
    }
    }

    updateEmployeeBtn() {
        this.updateEmployeeClicked = !this.updateEmployeeClicked;
      }

}