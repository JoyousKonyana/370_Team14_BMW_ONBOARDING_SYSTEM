
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Onboarder_Equipment, Equipment_Query } from '../_models';
import { Onboarder_EquipmentService, Equipment_QueryService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'my_equipment.component.html',
    styleUrls: ['./ss_equipment.component.css'] 
})

export class My_EquipmentComponent implements OnInit {

  x: Onboarder_Equipment[] = [];
  y: Equipment_Query[] = [];

  constructor(
    private xService: Onboarder_EquipmentService,
    private alertService: AlertService,
    private yService: Equipment_QueryService
) {

}

ngOnInit() { 
    this.loadAll();
}

private loadAll() {
  this.xService.getAllOnboarder_Equipment()
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
    { Equipment_ID: '1', Onboarder_ID: '321', Equipment_Check_Out_Date: '', Equipment_Check_Out_Description: '', Equipment_Check_In_Date: '', Equipment_Check_In_Description: ''},
    { Equipment_ID: '1', Onboarder_ID: '321', Equipment_Check_Out_Date: '', Equipment_Check_Out_Description: '', Equipment_Check_In_Date: '', Equipment_Check_In_Description: ''},
    { Equipment_ID: '1', Onboarder_ID: '321', Equipment_Check_Out_Date: '', Equipment_Check_Out_Description: '', Equipment_Check_In_Date: '', Equipment_Check_In_Description: ''},
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