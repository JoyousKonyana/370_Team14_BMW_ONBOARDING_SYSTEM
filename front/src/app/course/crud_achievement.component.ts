import { Achievment_Type } from '@app/_models';
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
  achievment_type: Achievment_Type[];
  badge: any[];

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
        this.achievment_type = achievment_type;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );

    this.achievment_typeService.getAllBadges()
    .pipe(first())
    .subscribe(
      badge => {
        this.badge = badge;
        console.log(this.badge);
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
      { AchievementTypeId: 1, BadgeId: 321, AchievementTypeDescription: ''},
      { AchievementTypeId: 1, BadgeId: 321, AchievementTypeDescription: ''},
      { AchievementTypeId: 1, BadgeId: 321, AchievementTypeDescription: ''},
      { AchievementTypeId: 1, BadgeId: 321, AchievementTypeDescription: ''},
    );
  }
    model3: Achievment_Type ={
      AchievementTypeId:1,
      AchievementTypeDescription:"",
      BadgeId:1
      
    }


  addAchievement_Type() { 
    this.model3.BadgeId = this.model.Badge_ID;
    this.model3.AchievementTypeDescription = this.model.Achievment_Type_Description;


    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
      this.model = {};
      


    }
    else if((Object.keys(this.model).length==2))
    {
      this.achievment_typeService.create(this.model3)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.achievment_type.push(this.model);
                    this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
                    this.model = {};
                    console.log(this.model);
                },
                error => {
                    this.alertService.error('Error, Creation was unsuccesful');
                });
    }
  }

  deleteAchievment_Type(i) {
    this.achievment_typeService.delete(i+1)
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
    this.model2.Achievment_Type_ID = this.achievment_type[editAchievment_TypeInfo].AchievementTypeId;
    this.model2.Badge_ID = this.achievment_type[editAchievment_TypeInfo].BadgeId;
    this.model2.Achievment_Type_Description = this.achievment_type[editAchievment_TypeInfo].AchievementTypeDescription;
    this.myValue = editAchievment_TypeInfo;

    this.updateAchievement_TypeClicked =!this.updateAchievement_TypeClicked;
  }

  updateAchievement_Type() {
    let editAchievment_TypeInfo = this.myValue;

    for(let i = 0; i < this.achievment_type.length; i++) {

      if(i == editAchievment_TypeInfo) 
      {
        this.achievment_typeService.update(editAchievment_TypeInfo+1, this.model2)
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
                });
      }
    }
    }

    addNewAchievement_TypeBtn() {
      this.newAchievement_TypeClicked = !this.newAchievement_TypeClicked;
      }

}