import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { ViewChild, ElementRef } from "@angular/core";

//Install it first
//import {jsPDF} from "jspdf";

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'report.component.html',
    styleUrls: ['./ss_report.component.css']
})
export class ReportComponent implements OnInit {
    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    constructor(
    ) {
    }

    ngOnInit() {
    }

    //selected = ''; //For navigating what report to be generated

    onboarder_report = [
        { name: 'Harry', surname: 'Potter', employee_id: '123456', date_enrolled: '2007', lesson_completed: '2 of 10 Completed', progress: '80%' },
        { name: 'Hermione', surname: 'Granger', employee_id: '123456', date_enrolled: '2005', lesson_completed: '6 of 10 Completed', progress: '40%' },
        { name: 'Ron', surname: 'Weasley', employee_id: '123456', date_enrolled: '2004', lesson_completed: '2 of 10 Completed', progress: '20%' },
        { name: 'Draco', surname: 'Malfoy', employee_id: '123456', date_enrolled: '2002', lesson_completed: '5 of 10 Completed', progress: '40%' },
      ];

    certificate = [
        { name: 'Jaxk', surname: 'Graylish', course: 'Sexual Harrasment Course', completion_date: '13 March 2021', postion: 'junior Developer' },
    ];

    color;

    model: any = {};
    model2: any = {}; 

}