import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';
import { Router,ActivatedRoute } from '@angular/router';

import { Learning_Outcome } from '../_models';
import { AlertService, Learning_OutcomeService } from '../_services';

@Component({ 
    templateUrl: 'take_learning_outcome.component.html',
    styleUrls: ['./ss_onboarder.component.css'] 
})

export class Take_Learning_OutcomeComponent implements OnInit {

  lesson_outcome: Learning_Outcome[] = [];

  constructor(
      private learning_outcomeService: Learning_OutcomeService,
      private alertService: AlertService,
      private _Activatedroute:ActivatedRoute,
      private _router:Router,
  ) {

  }

  id;

  sub;

  ngOnInit() { 
      this.loadAll();

      this.id=this._Activatedroute.snapshot.paramMap.get("id");
  }

  private loadAll() {
    this.learning_outcomeService.getLearning_OutcomeById(this._Activatedroute.snapshot.paramMap.get("id"))
    .pipe(first())
    .subscribe(
      lesson_outcome => {
        this.lesson_outcome = lesson_outcome;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

  //Remove this bad boy
  testData() {
    this.lesson_outcome.push(
      { Learning_Outcome_ID: 123, Lesson_ID: 1, Lesson_Outcome_Description: 'This lesson outcome you will learn how to take to women'},
      { Learning_Outcome_ID: 234, Lesson_ID: 1, Lesson_Outcome_Description: 'This lesson outcome you will learn how to take to women'},
      { Learning_Outcome_ID: 345, Lesson_ID: 1, Lesson_Outcome_Description: 'This lesson outcome you will learn how to take to women'},
      { Learning_Outcome_ID: 456, Lesson_ID: 1, Lesson_Outcome_Description: 'This lesson outcome you will learn how to take to women'},
      { Learning_Outcome_ID: 567, Lesson_ID: 1, Lesson_Outcome_Description: 'This lesson outcome you will learn how to take to women'},
    );
  }

}