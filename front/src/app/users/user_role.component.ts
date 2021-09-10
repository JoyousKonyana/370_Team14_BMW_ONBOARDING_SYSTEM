
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User_Role } from '../_models';
import { User_RoleService, AuthenticationService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'user_role.component.html',
    styleUrls: ['./user_role.component.css'] 
})

export class User_RoleComponent implements OnInit {

  // dataSaved = false;  
  // CourseForm: any;
  // user_role: User_Role[] = [];

  // faqIdUpdate = null;  
  // massage = null;

  constructor(
  //     private user_roleService: User_RoleService,
  //     private alertService: AlertService
   ) {

   }

   ngOnInit() { 
  //     this.loadAll();
   }

  

  // private loadAll() {
  //   this.user_roleService.getAllUser_Role()
  //   .pipe(first())
  //   .subscribe(
  //     user_role => {
  //       //this.faq = faq;
  //       this.user_role = user_role;
  //     },
  //     error => {
  //       this.alertService.error('Error, Data was unsuccesfully retrieved');
  //     } 
  //   );
  // }

  //   newUser_RoleClicked = false;

  // color;

  // model: any = {};
  // model2: any = {}; 

  // //Remove this bad boy
  // testData() {
  //   this.user_role.push(
  //     { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
  //     { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
  //     { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
  //     { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
  //   );
  // }

  // addCourse() { 
  //   if(Object.keys(this.model).length < 2)
  //   {
  //     this.alertService.error("Error, you have an empty feild");
  //     console.log('Empty');
  //     this.newUser_RoleClicked = !this.newUser_RoleClicked;
  //     this.model = {};
  //   }
  //   else if((Object.keys(this.model).length==2))
  //   {
  //     this.user_roleService.create(this.model)
  //           .pipe(first())
  //           .subscribe(
  //               data => {
  //                   this.alertService.success('Creation was successful', true);
  //                   this.user_role.push(this.model);
  //                   this.newCourseClicked = !this.newCourseClicked;
  //                   this.model = {};
  //               },
  //               error => {
  //                   this.alertService.error('Error, Creation was unsuccesful');
                    
  //                   this.user_role.push(this.model);//Please Remove this When the you have connected to the API
  //                   this.newCourseClicked = !this.newCourseClicked;
  //                   this.model = {};
  //               });
  //   }
  // }
    
  
  // deleteUser_Role(i) {
  //   this.user_roleService.delete(i)
  //           .pipe(first())
  //           .subscribe(
  //               data => {
  //                   this.alertService.success('Deletion was successful', true);

  //                   this.user_role.splice(i, 1);
  //                   console.log(i);
  //               },
  //               error => {
  //                   this.alertService.error('Error, Deletion was unsuccesful');
                    
  //                   this.user_role.splice(i, 1);//Please Remove this When the you have connected to the API
  //                   console.log(i);
  //               });
  // }

  // myValue;

  // editCourse(editCourseInfo) {
  //   this.model2.Course_ID = this.user_role[editCourseInfo].Course_ID;
  //   this.model2.Course_Description = this.course[editCourseInfo].Course_Description;
  //   this.model2.Due_Date = this.user_role[editCourseInfo].Due_Date;
  //   this.model2.Message = this.user_role[editCourseInfo].Message;
  //   this.myValue = editCourseInfo;
  // }

  // updateCourse() {
  //   let editCourseInfo = this.myValue;

  //   for(let i = 0; i < this.user_role.length; i++) {

  //     if(i == editCourseInfo) 
  //     {
  //       this.user_roleService.update(editCourseInfo, this.model2)
  //           .pipe(first())
  //           .subscribe(
  //               data => {
  //                   this.alertService.success('Update was successful', true);

  //                   this.user_role[i] = this.model2;
  //                   this.model2 = {};
  //               },
  //               error => {
  //                   this.alertService.error('Error, Update was unsuccesful');
                    
  //                   this.user_role[i] = this.model2;//Remove this code when you connect to the API
  //                   this.model2 = {};
  //               });
  //     }
  //   }
  //   }

  //   addNewCourseBtn() {
  //       this.newCourseClicked = !this.newCourseClicked;
  //     }


}