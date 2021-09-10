import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Onboarder } from '../_models';
import { OnboarderService, AlertService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'onboarder.component.html',
    styleUrls: ['./ss_administrator.component.css'] 
})

export class OnboarderComponent implements OnInit {

    dataSaved = false;  
    faqForm: any;
    onboarder: Onboarder[] = [];

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private onboarderService: OnboarderService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAll();
  }

  

  private loadAll() {
    this.onboarderService.getAllOnboarder()
    .pipe(first())
    .subscribe(
      onboarder => {
        this.onboarder = onboarder;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newFAQClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

  //Remove this bad boy
  testData() {
    this.onboarder.push(
      { Onboarder_ID: 123, Employee_ID: 12345, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 234, Employee_ID: 23456, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 345, Employee_ID: 34567, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 456, Employee_ID: 45678, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
    )
  }

    newOnboarderClicked = false;

  deleteOnboarder(i) {
    this.onboarderService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.onboarder.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                    
                    this.onboarder.splice(i, 1);//Please Remove this When the you have connected to the API
                    console.log(i);
                });
  }

  myValue;

    addNewOnboarderBtn() {
        this.newOnboarderClicked = !this.newOnboarderClicked;
      }

}