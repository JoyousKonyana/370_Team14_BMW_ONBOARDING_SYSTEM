
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { AssignEquipment, Equipment_Query } from '../_models';
import { EquipmentService, Equipment_QueryService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'my_equipment.component.html',
    styleUrls: ['./ss_equipment.component.css'] 
})

export class My_EquipmentComponent implements OnInit {

  // x: AssignEquipment[] = [];
  x:any;
  y: Equipment_Query[] = [];

  constructor(
    private xService: EquipmentService,
    private alertService: AlertService,
    private yService: Equipment_QueryService
) {

}

ngOnInit() { 
    this.loadAll();
}

private loadAll() {
  this.xService.GetAssignedEquipment(1)
  .pipe(first())
  .subscribe(
    x => {
      this.x = x;
    },
    error => {
      this.alertService.error('Error, Data was unsuccesfully retrieved');
    } 
  );
}

testData() {
  this.x.push(
    { EquipmentId: 1, OnboarderId: 321, EquipmentCheckOutDate: new Date(), EquipmentCheckOutCondition: '', EquipmentCheckInDate:  new Date(), EquipmentCheckInCondition: ''},
    { EquipmentId: 1, OnboarderId: 321, EquipmentCheckOutDate: new Date(), EquipmentCheckOutCondition: '', EquipmentCheckInDate: new Date(), EquipmentCheckInCondition: ''},
    { EquipmentId: 1,  OnboarderId: 321,EquipmentCheckOutDate: new Date(), EquipmentCheckOutCondition: '',  EquipmentCheckInDate: new Date(), EquipmentCheckInCondition: ''},
  );
}

    newUser_RoleClicked = false;

    newReport_QueryClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

  myValue;

  editReport_Query(editReport_QueryInfo) {
    this.newReport_QueryClicked = !this.newReport_QueryClicked;

    this.model2.status = this.y[editReport_QueryInfo].Equipment_Query_ID;
    this.model2.description = this.y[editReport_QueryInfo].Equipment_Query_Description;
    this.myValue = editReport_QueryInfo;
  }
  

  updateReport_Query() {
    let editReport_QueryInfo = this.myValue;

    for(let i = 0; i < this.x.length; i++) {

      if(i == editReport_QueryInfo) 
      {
        this.yService.create(editReport_QueryInfo + this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Report was successful', true);

                    this.y[i] = this.model2;
                    this.model2 = {};
                },
                error => {
                    this.alertService.error('Error, Report was unsuccesful');
                    
                    this.y[i] = this.model2;//Remove this code when you connect to the API
                    this.model2 = {};
                });
      }
    }

    this.newReport_QueryClicked = !this.newReport_QueryClicked;
  }

  CloseReport_QueryBtn() {
    this.newReport_QueryClicked = !this.newReport_QueryClicked;
  }

}