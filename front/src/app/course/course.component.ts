import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Course } from '../_models';
import { CourseService, AuthenticationService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'course.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class CourseComponent implements OnInit {

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
        this.course = course;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newCourseClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

  //Remove this bad boy
  testData() {
    this.course.push(
      { CourseId: 1, CourseDescription: '321', CourseDueDate: '', CourseName: ''},
      { CourseId: 1, CourseDescription: '321', CourseDueDate: '', CourseName: ''},
      { CourseId: 1, CourseDescription: '321', CourseDueDate: '', CourseName: ''},
      { CourseId: 1, CourseDescription: '321', CourseDueDate: '', CourseName: ''},
    );
  }

  addCourse() { 
    if(Object.keys(this.model).length < 3)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.newCourseClicked = !this.newCourseClicked;
      this.model = {};
    }
    else if((Object.keys(this.model).length== 3))
    {
      this.courseService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.course.push(this.model);
                    this.newCourseClicked = !this.newCourseClicked;
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Creation was unsuccesful');
                });
    }
  }
    
  
  deleteCourse(i) {
    this.courseService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.course.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                    
                    this.course.splice(i, 1);//Please Remove this When the you have connected to the API
                    console.log(i);
                });
  }

  myValue;

  editCourse(editCourseInfo) {
    this.model2.Course_ID = this.course[editCourseInfo].CourseId;
    this.model2.Course_Description = this.course[editCourseInfo].CourseDescription;
    this.model2.Due_Date = this.course[editCourseInfo].CourseDueDate;
    this.model2.Message = this.course[editCourseInfo].CourseName;
    this.myValue = editCourseInfo;
  }

  updateCourse() {
    let editCourseInfo = this.myValue;

    for(let i = 0; i < this.course.length; i++) {

      if(i == editCourseInfo) 
      {
        this.courseService.update(editCourseInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);

                    this.course[i] = this.model2;
                    this.model2 = {};
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                });
      }
    }
    }

    addNewCourseBtn() {
        this.newCourseClicked = !this.newCourseClicked;
      }

      

}