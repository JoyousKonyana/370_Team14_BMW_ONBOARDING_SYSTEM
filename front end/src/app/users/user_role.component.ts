
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

   addUser_Role() { 
     if(Object.keys(this.model).length < 2)
     {
       this.alertService.error("Error, you have an empty feild");
       console.log('Empty');
       this.newUser_RoleClicked = !this.newUser_RoleClicked;
       this.model = {};
     }
     else if((Object.keys(this.model).length==2))
     {
       this.user_roleService.create(this.model)
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
                    this.newUser_RoleClicked = !this.newUser_RoleClicked;
                     this.model = {};
                 });
     }
   }
    
  
   deleteUser_Role(i) {
     this.user_roleService.delete(i)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Deletion was successful', true);

                     this.user_role.splice(i, 1);
                     console.log(i);
                 },
                 error => {
                     this.alertService.error('Error, Deletion was unsuccesful');
                    
                     console.log('Error, Deletion was unsuccesful');
                 });
   }

   myValue;

   editUser_Role(editUser_RoleInfo) {
     this.model2.User_Role_ID = this.user_role[editUser_RoleInfo].User_Role_ID;
     this.model2.User_Role_Acess_Description = this.user_role[editUser_RoleInfo].User_Role_Acess_Description;
     this.model2.User_Role_Name = this.user_role[editUser_RoleInfo].User_Role_Name;
     this.myValue = editUser_RoleInfo;
   }

   updateUser_Role() {
     let editUser_RoleInfo = this.myValue;

     for(let i = 0; i < this.user_role.length; i++) {

       if(i == editUser_RoleInfo) 
       {
         this.user_roleService.update(editUser_RoleInfo, this.model2)
             .pipe(first())
             .subscribe(
                 data => {
                     this.alertService.success('Update was successful', true);

                     this.user_role[i] = this.model2;
                     this.model2 = {};
                 },
                 error => {
                     this.alertService.error('Error, Update was unsuccesful');
                     this.model2 = {};
                 });
       }
     }
     }

     addNewUser_RoleBtn() {
         this.newUser_RoleClicked = !this.newUser_RoleClicked;
       }


}