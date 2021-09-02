import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Achievment_Type } from '../_models';
import { Achievment_TypeService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'crud_achievement.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class CRUD_AchievementComponent implements OnInit {

  dataSaved = false; 
  achievment_type: Achievment_Type[] = [];

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private achievment_typeService: Achievment_TypeService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAll();
  }

  

  private loadAll() {
    this.achievment_typeService.getAllAchievment_Type()
    .pipe(first())
    .subscribe(
      achievment_type => {
        //this.faq = faq;
        this.achievment_type = achievment_type;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newAchievement_TypeClicked = false;
    updateAchievement_TypeClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

  //Remove this bad boy
  testData() {
    this.achievment_type.push(
      { Achievment_Type_ID: 1, Badge_ID: '321', Achievment_Type_Description: ''},
      { Achievment_Type_ID: 1, Badge_ID: '321', Achievment_Type_Description: ''},
      { Achievment_Type_ID: 1, Badge_ID: '321', Achievment_Type_Description: ''},
      { Achievment_Type_ID: 1, Badge_ID: '321', Achievment_Type_Description: ''},
    );
  }

  addCourse() { 
    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
      this.model = {};
    }
    else if((Object.keys(this.model).length==2))
    {
      this.achievment_typeService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.achievment_type.push(this.model);
                    this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Creation was unsuccesful');
                    
                    this.achievment_type.push(this.model);//Please Remove this When the you have connected to the API
                    this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
                    this.model = {};
                });
    }
  }
    
  
  deleteAchievment_Type(i) {
    this.achievment_typeService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.achievment_type.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                    
                    this.achievment_type.splice(i, 1);//Please Remove this When the you have connected to the API
                    console.log(i);
                });
  }

  myValue;

  editAchievment_Type(editAchievment_TypeInfo) {
    this.model2.Achievment_Type_ID = this.achievment_type[editAchievment_TypeInfo].Achievment_Type_ID;
    this.model2.Badge_ID = this.achievment_type[editAchievment_TypeInfo].Badge_ID;
    this.model2.Achievment_Type_Description = this.achievment_type[editAchievment_TypeInfo].Achievment_Type_Description;
    this.myValue = editAchievment_TypeInfo;

    this.updateAchievement_TypeClicked =!this.updateAchievement_TypeClicked;
  }

  updateAchievement_Type() {
    let editAchievment_TypeInfo = this.myValue;

    for(let i = 0; i < this.achievment_type.length; i++) {

      if(i == editAchievment_TypeInfo) 
      {
        this.achievment_typeService.update(editAchievment_TypeInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);

                    this.achievment_type[i] = this.model2;
                    this.model2 = {};
                    this.updateAchievement_TypeClicked =!this.updateAchievement_TypeClicked;
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                    
                    this.achievment_type[i] = this.model2;//Remove this code when you connect to the API
                    this.model2 = {};
                });
      }
    }
    }

    addNewAchievement_TypeBtn() {
      this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
      }

}