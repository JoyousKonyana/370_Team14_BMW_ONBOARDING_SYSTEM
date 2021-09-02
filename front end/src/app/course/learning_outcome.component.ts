import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Learning_Outcome } from '../_models';
import { Learning_OutcomeService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'learning_outcome.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class Learning_OutcomeComponent implements OnInit {
  dataSaved = false;  
  CourseForm: any;
  searchText: any;
  lesson_outcome: Learning_Outcome[] = [];

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private learning_outcomeService: Learning_OutcomeService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAll();
  }

  

  private loadAll() {
    this.learning_outcomeService.getAllLearning_Outcome()
    .pipe(first())
    .subscribe(
      lesson_outcome => {
        //this.faq = faq;
        this.lesson_outcome = lesson_outcome;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newLesson_OutcomeClicked = false;

    updateLearning_OutcomeClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

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

  addLearning_Outcome() { 
    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.newLesson_OutcomeClicked = !this.newLesson_OutcomeClicked;
      this.model = {};
    }
    else if((Object.keys(this.model).length==2))
    {
      this.learning_outcomeService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.lesson_outcome.push(this.model);
                    this.newLesson_OutcomeClicked = !this.newLesson_OutcomeClicked;
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Creation was unsuccesful');
                    
                    this.lesson_outcome.push(this.model);//Please Remove this When the you have connected to the API
                    this.newLesson_OutcomeClicked = !this.newLesson_OutcomeClicked;
                    this.model = {};
                });
    }
  }
    
  
  deleteLearning_Outcome(i) {
    this.learning_outcomeService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.lesson_outcome.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                    
                    this.lesson_outcome.splice(i, 1);//Please Remove this When the you have connected to the API
                    console.log(i);
                });
  }

  myValue;

  editLearning_Outcome(editLearning_OutcomeInfo) {
    this.updateLearning_OutcomeClicked = !this.updateLearning_OutcomeClicked;

    this.model2.Learning_Outcome_ID = this.lesson_outcome[editLearning_OutcomeInfo].Learning_Outcome_ID;
    this.model2.Lesson_Outcome_Description = this.lesson_outcome[editLearning_OutcomeInfo].Lesson_Outcome_Description;
    this.myValue = editLearning_OutcomeInfo;
  }

  updateLearning_Outcome() {
    let editCourseInfo = this.myValue;

    for(let i = 0; i < this.lesson_outcome.length; i++) {

      if(i == editCourseInfo) 
      {
        this.learning_outcomeService.update(editCourseInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);

                    this.lesson_outcome[i] = this.model2;
                    this.model2 = {};
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                    
                    this.lesson_outcome[i] = this.model2;//Remove this code when you connect to the API
                    this.model2 = {};
                });
      }
    }
    }

    addNewLearning_OutcomeBtn() {
      this.newLesson_OutcomeClicked = !this.newLesson_OutcomeClicked;
      }

      closeUpdate(){
        this.updateLearning_OutcomeClicked = !this.updateLearning_OutcomeClicked;
      }

}