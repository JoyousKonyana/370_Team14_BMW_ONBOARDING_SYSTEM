import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'ss_users.component.html',
    styleUrls: ['./home.component.css']
})
export class SS_UsersComponent implements OnInit {
    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    public sidebarShow: boolean = false;

    constructor(
    ) {
    }

    ngOnInit() {
    }
}