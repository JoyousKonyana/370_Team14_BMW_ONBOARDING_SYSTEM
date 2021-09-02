import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Course } from '../_models';
import { CourseService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'take_course.component.html',
    styleUrls: ['./ss_onboarder.component.css'] 
})

export class Take_CourseComponent implements OnInit {

  course: Course[] = [];

  constructor(
      private courseService: CourseService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAll();
  }

  private loadAll() {
    this.courseService.getAllCourse()
    .pipe(first())
    .subscribe(
      course => {
        //this.faq = faq;
        this.course = course;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newUser_RoleClicked = false;

  //Remove this bad boy
  testData() {
    this.course.push(
      { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
      { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
      { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
      { Course_ID: 1, Course_Description: '321', Due_Date: '', Message: ''},
    );
  }

}