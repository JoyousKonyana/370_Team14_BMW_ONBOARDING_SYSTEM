import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'ss_equipment.component.html',
    styleUrls: ['./ss_equipment.component.css']
})
export class SS_EquipmentComponent implements OnInit {
    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    constructor(
    ) {
    }

    ngOnInit() {
    }
}