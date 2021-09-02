import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Onboarder, Equipment, Onboarder_Equipment } from '../_models';
import { OnboarderService, EquipmentService, Onboarder_EquipmentService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'assign_equipment.component.html',
    styleUrls: ['./ss_administrator.component.css'] 
})

export class Assign_EquipmentComponent implements OnInit {
  dataSaved = false;  
  faqForm: any;

  equipment: Equipment[] = [];
  onboarder: Onboarder[] = [];
  onboarder_equipment: Onboarder_Equipment[] = [];

  //filtered: Object[]

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private onboarderService: OnboarderService,
      private equipmentService: EquipmentService,
      private onboarder_equipmentService: Onboarder_EquipmentService,

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

  addOnboarder_Equipment() { 
    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.model = {};
    }
    else if((Object.keys(this.model).length==2))
    {
      this.onboarder_equipmentService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Assign was successful', true);
                    this.onboarder_equipment.push(this.model);
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Assign was unsuccesful');
                    
                    this.model = {};
                });
    }
  }

  myValue;

}