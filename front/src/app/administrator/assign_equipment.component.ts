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
      { Equipment_ID: 1, Equipment_Type_ID: 321, EquipmentTradeInStatus: '', Equipment_Description: '', WarrantyId: '', EquipmentTradeUnDeadline: '', EquipmentBrandId: 1, EquipmentSerialNumber: 545},
      
    );
    this.onboarder.push(
      { OnboarderId: 123, EmployeeId: 12345, EquipmentTypeId: 1, BookingId: 1, SuggestiondId: 1, RegistrationId: 1 },
      { OnboarderId: 123, EmployeeId: 12345, EquipmentTypeId: 1, BookingId: 1, SuggestiondId: 1, RegistrationId: 1 },
      { OnboarderId: 123, EmployeeId: 12345, EquipmentTypeId: 1, BookingId: 1, SuggestiondId: 1, RegistrationId: 1 },
      { OnboarderId: 123, EmployeeId: 12345, EquipmentTypeId: 1, BookingId: 1, SuggestiondId: 1, RegistrationId: 1 }
     
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