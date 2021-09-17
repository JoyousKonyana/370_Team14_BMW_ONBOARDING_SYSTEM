import { User } from './../_models/user';

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
  user_role: User_Role[] = [];

  constructor(
       private user_roleService: User_RoleService,
       private alertService: AlertService
   ) {

   }

   ngOnInit() { 
       this.loadAll();
   }

   private loadAll() {
     this.user_roleService.getAllUser_Role()
     .pipe(first())
     .subscribe(
       user_role => {
         this.user_role = user_role;
       },
       error => {
         this.alertService.error('Error, Data was unsuccesfully retrieved');
       } 
     );
   }

     newUser_RoleClicked = false;

   model: any = {};
   model2: any = {}; 

  model3: User_Role = {
    UserRoleId: 1,
    UserRoleAccessDescription: '',
    UserRoleName:  '',
  }

  //Remove this bad boy
   testData() {
     this.user_role.push(
       { UserRoleId: 1, UserRoleAccessDescription: '321',  UserRoleName: ''},
       { UserRoleId: 1, UserRoleAccessDescription: '321', UserRoleName: ''},
       { UserRoleId: 1, UserRoleAccessDescription: '321', UserRoleName: ''},
       { UserRoleId: 1, UserRoleAccessDescription: '321', UserRoleName: ''},
     );
   }

   addUser_Role() { 
     if(Object.keys(this.model).length < 2)
     {
       this.alertService.error("Error, you have an empty feild");
       this.newUser_RoleClicked = !this.newUser_RoleClicked;
       this.model = {};
     }
     else if((Object.keys(this.model).length==2))
     {
      this.model3.UserRoleAccessDescription = this.model.UserRoleAccessDescription;
      this.model3.UserRoleName = this.model.UserRoleName;

       this.user_roleService.create(this.model3)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Creation was successful', true);
                     this.user_role.push(this.model);
                     this.newUser_RoleClicked = !this.newUser_RoleClicked;
                     this.model = {};
                 },
                 error => {
                     this.alertService.error('Error, Creation was unsuccesful');
                 });
     }
   }
    
  
   deleteUser_Role(i) {
     this.user_roleService.delete(i+1)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Deletion was successful', true);
                     this.user_role.splice(i, 1);
                 },
                 error => {
                     this.alertService.error('Error, Deletion was unsuccesful');
                 });
   }

   myValue;

   editUser_Role(editUser_RoleInfo) {
     this.model2.UserRoleAccessDescription = this.user_role[editUser_RoleInfo].UserRoleAccessDescription;
     this.model2.UserRoleName = this.user_role[editUser_RoleInfo].UserRoleName;
     this.myValue = editUser_RoleInfo;
   }

   updateUser_Role() {
     let editUsser_RoleInfo = this.myValue;

     for(let i = 0; i < this.user_role.length; i++) 
       if(i == editUsser_RoleInfo) 
       {
          this.model3.UserRoleAccessDescription = this.model2.UserRoleAccessDescription;
          this.model3.UserRoleName = this.model2.UserRoleName;

         this.user_roleService.update(editUsser_RoleInfo, this.model3)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Update was successful', true);
                     this.user_role[i] = this.model2;
                     this.model2 = {};
                 },
                 error => {
                     this.alertService.error('Error, Update was unsuccesful');
                 });
       }
     }

     addNewUser_RoleBtn() {
         this.newUser_RoleClicked = !this.newUser_RoleClicked;
       }
}