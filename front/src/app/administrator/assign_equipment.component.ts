import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Onboarder, Equipment, AssignEquipment, Onboarder_Equipment } from '../_models';
import { OnboarderService, EquipmentService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'assign_equipment.component.html',
    styleUrls: ['./ss_administrator.component.css'] 
})

export class Assign_EquipmentComponent implements OnInit {
  dataSaved = false;  
  faqForm: any;

  equipment: Equipment[] = [];
  onboarder: Onboarder[] = [];
  onboarder_equipment: AssignEquipment[] = [];

  //filtered: Object[]

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private onboarderService: OnboarderService,
      private equipmentService: EquipmentService,

      private alertService: AlertService
  ) {
  }

  ngOnInit() { 
      this.loadAll();
  }

private loadAll() {
  this.equipmentService.getAllEquipment()
    .pipe(first())
    .subscribe(
      equipment => {
        this.equipment = equipment;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

  model: any = {};
  model2: any = {}; 

  //Remove this bad boy
  testData() {
    this.equipment.push(
      { Equipment_ID: 1, Equipment_Type_ID: '321', Equipment_Trade_In_Status_ID: '', Equipment_Description: '', Equipment_Warranty: '', Equpment_Trade_In_Date: '', Equipment_Brand: 'Acer', Serial_Number: 545},
      
    );
    this.onboarder.push(
      { Onboarder_ID: 123, Employee_ID: 12345, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 234, Employee_ID: 23456, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 345, Employee_ID: 34567, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
      { Onboarder_ID: 456, Employee_ID: 45678, Equipment_Type_ID: 1, Booking_ID: 1, Suggestion_ID: 1, Registration_ID: 1 },
    );
  }

  model3:AssignEquipment = {
    EquipmentId: 1,
    OnboarderId: 1, 
    EquipmentCheckOutDate:new Date(),  
    EquipmentCheckOutCondition: '2018-01-03', 
    EquipmentCheckInCondition: '2018-01-03',
    EquipmentCheckInDate:new Date()
  } ;

  addOnboarder_Equipment() { 

    this.model3.EquipmentId=this.model.Equipment_ID;
    this.model3.OnboarderId = this.model.Onboarder_ID;
    this.model3.EquipmentCheckOutDate=this.model.Equipment_Check_Out_Description;
    this.model3.EquipmentCheckOutCondition = this.model.Equipment_Check_Out_Date;

    if(Object.keys(this.model).length < 4)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.model = {};
    }
    else if((Object.keys(this.model).length==4))
    {
      this.equipmentService.AssignEquipment(this.model3)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Assign was successful', true);
                    this.onboarder_equipment.push(this.model);
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Assign was unsuccesful');
                });
    }
  }

  myValue;

}