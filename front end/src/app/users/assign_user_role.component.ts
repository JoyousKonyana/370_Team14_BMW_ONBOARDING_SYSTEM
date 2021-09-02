import { AlertService } from './../_services/alert.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({ 
    templateUrl: 'assign_user_role.component.html'
})
export class Assign_User_RoleComponent implements OnInit {
    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    constructor(
        xService: UserService,
        alertService: AlertService
    ) {
    }

    ngOnInit() {
    }

    model2: any = {};

    submit() { 
        if(Object.keys(this.model2).length < 2)
        {
          this.alertService.error("Error, you have an empty feild");
          console.log('Empty');
          this.model2 = {};
        }
        else if((Object.keys(this.model2).length==2))
        {
          this.xService.create(this.model2)
                .pipe(first())
                .subscribe(
                    data => {
                        this.alertService.success('Assign was successful', true);
                        this.model2 = {};
                    },
                    error => {
                        this.alertService.error('Error, Assign was unsuccesful');
                    });
        }
      }
  
}