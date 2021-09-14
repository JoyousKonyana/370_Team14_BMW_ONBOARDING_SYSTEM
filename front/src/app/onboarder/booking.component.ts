import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'booking.component.html',
    styleUrls: ['./ss_onboarder.component.css'] 
})

export class BookingComponent implements OnInit {

    constructor(
    ) {
    }

    ngOnInit() {
        
    }

}