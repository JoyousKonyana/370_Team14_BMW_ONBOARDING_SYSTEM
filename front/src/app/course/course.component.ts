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

  searchText;

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

  model3:Course = {
    CourseId: 1,
    CourseDescription:'',
    CourseDueDate: '',
    CourseName: '',
  };

  //Remove this bad boy
  testData() {
    this.course.push(
      { CourseId: 1, CourseDescription: 'jfsd', CourseDueDate: '213', CourseName: '3212'},
      { CourseId: 2, CourseDescription: 'fklsdm', CourseDueDate: '21', CourseName: 'as'},
      { CourseId: 3, CourseDescription: 'cxzkl', CourseDueDate: '21', CourseName: ''},
      { CourseId: 4, CourseDescription: '321', CourseDueDate: '', CourseName: ''},
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
      this.model3.CourseDescription = this.model.CourseDescription;
      this.model3.CourseDueDate = this.model.CourseDueDate;
      this.model3.CourseName = this.model.CourseName;
    
      this.courseService.create(this.model3)
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
    this.courseService.delete(i+1)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.course.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                });
  }

  myValue;

  editCourse(editCourseInfo) {
    this.model2.CourseDescription = this.course[editCourseInfo].CourseDescription;
    this.model2.CourseDueDate = this.course[editCourseInfo].CourseDueDate;
    this.model2.CourseName = this.course[editCourseInfo].CourseName;
    this.myValue = editCourseInfo;
  }

  updateCourse() {
    let editCourseInfo = this.myValue;

    for(let i = 0; i < this.course.length; i++) {

      if(i == editCourseInfo) 
      {
        this.model3.CourseDescription = this.model2.CourseDescription;
        this.model3.CourseDueDate = this.model2.CourseDueDate;
        this.model3.CourseName = this.model2.CourseName;

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