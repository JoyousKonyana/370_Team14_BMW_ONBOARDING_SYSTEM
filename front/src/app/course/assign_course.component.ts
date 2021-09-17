import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Onboarder, Course, Onboarder_Course_Enrollment } from '../_models';
import { OnboarderService, CourseService, Onboarder_Course_EnrollmentService, AuthenticationService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'assign_course.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class Assign_CourseComponent implements OnInit {

  dataSaved = false;  
  faqForm: any;

  onboarder: Onboarder[] = [];
  course: Course[] = [];
  onboarder_course_enrollment: Onboarder_Course_Enrollment[] = [];

  filtered: Object[]

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private onboarderService: OnboarderService,
      private courseService: CourseService,
      private onboarder_course_enrollmentService: Onboarder_Course_EnrollmentService,

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
        this.course = course;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );

    // this.onboarderService.getAllOnboarder()
    // .pipe(first())
    // .subscribe(
    //   onboarder => {
    //     this.onboarder = onboarder;
    //   },
    //   error => {
    //     this.alertService.error('Error, Data was unsuccesfully retrieved');
    //   } 
    // );
  }

  model: any = {};
  model2: any = {};

  addCourse_Onboarder_Enrollment() { 
    if(Object.keys(this.model).length < 3)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.model = {};
    }
    else if((Object.keys(this.model).length==3))
    {
      this.onboarder_course_enrollmentService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Assign was successful', true);
                    this.onboarder_course_enrollment.push(this.model);
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Assign was unsuccesful');
                    
                    this.onboarder_course_enrollment.push(this.model);//Please Remove this When the you have connected to the API
                    this.model = {};
                });
    }
  }

  myValue;

}