import { Component, OnInit, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';


import { Employee } from '../_models';
import { EmployeeService, AuthenticationService, AlertService } from '../_services';



@Component({ 
    templateUrl: 'crud_employee.component.html',
    styleUrls: ['./ss_administrator.component.css'] 
})

export class CRUD_EmployeeComponent implements OnInit {
  
  dataSaved = false;  
  employeeForm: any;  
  //employee: Observable<Employee[]>;  
  employeeIdUpdate = null;  
  massage = null;
  employee: Employee[] = [];

  constructor(
      private employeeService: EmployeeService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
    this.loadAll();
}

private loadAll() {
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

  //Remove this bad boy
  testData() {
    this.employee.push(
      { Employee_ID: 1, Department_ID: 98, first_name: 'In y page', Middle_Name: '', Last_Name: '', Title: '', Gender_ID: '', ID_Number: '',  Contact_Number: '', Job_Title: '', Address_ID: 89 },
      { Employee_ID: 2, Department_ID: 90, first_name: 'In y page', Middle_Name: '', Last_Name: '', Title: '', Gender_ID: '', ID_Number: '',  Contact_Number: '', Job_Title: '', Address_ID: 89},
      { Employee_ID: 3, Department_ID: 98, first_name: 'In y page', Middle_Name: '', Last_Name: '', Title: '', Gender_ID: '', ID_Number: '',  Contact_Number: '', Job_Title: '', Address_ID: 89 },
    )
  }

    newEmployeeClicked = false;

  color;

  model: any = {};
  model2: any = {};
  
  deleteEmployee(i) {
    this.employeeService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.employee.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                    
                    this.employee.splice(i, 1);//Please Remove this When the you have connected to the API
                    console.log(i);
                });
  }

  myValue;

  editEmployee(editEmployeeInfo) {
    this.model2.Employee_ID = this.employee[editEmployeeInfo].Employee_ID;
    this.model2.Department_ID = this.employee[editEmployeeInfo].Department_ID;
    this.model2.first_name = this.employee[editEmployeeInfo].first_name;
    this.model2.Middle_Name = this.employee[editEmployeeInfo].Middle_Name;
    this.model2.Last_Name = this.employee[editEmployeeInfo].Last_Name;
    this.model2.Title = this.employee[editEmployeeInfo].Title;
    this.model2.Gender_ID = this.employee[editEmployeeInfo].Gender_ID;
    this.model2.ID_Number = this.employee[editEmployeeInfo].ID_Number;
    this.model2.Contact_Number = this.employee[editEmployeeInfo].Contact_Number;
    this.model2.Job_Title = this.employee[editEmployeeInfo].Job_Title;
    this.model2.Address_ID = this.employee[editEmployeeInfo].Address_ID;
    this.myValue = editEmployeeInfo;
  }
    
  updateEmployee() {
    let editEmployeeInfo = this.myValue;

    for(let i = 0; i < this.employee.length; i++) {

      if(i == editEmployeeInfo) 
      {
        this.employeeService.update(editEmployeeInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);

                    this.employee[i] = this.model2;
                    this.model2 = {};
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                    
                    this.employee[i] = this.model2;//Remove this code when you connect to the API
                    this.model2 = {};
                });
      }
    }
    }

    addNewEmployeeBtn() {
        this.newEmployeeClicked = !this.newEmployeeClicked;
      }

}