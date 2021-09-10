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
    ) {
    }

    ngOnInit() {
    }
  
}