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
    onboarder: Onboarder[] = [];

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

    newOnboarderClicked = false;

  deleteOnboarder(i) {
    this.onboarderService.delete(i+1)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.onboarder.splice(i, 1);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                });
  }

  myValue;

    addNewOnboarderBtn() {
        this.newOnboarderClicked = !this.newOnboarderClicked;
      }

}