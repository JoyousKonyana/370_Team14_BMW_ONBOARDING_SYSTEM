import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'ss_onboarder.component.html',
    styleUrls: ['./ss_onboarder.component.css']
})
export class SS_OnboarderComponent implements OnInit {
    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    constructor(
    ) {
    }

    ngOnInit() {
    }
}