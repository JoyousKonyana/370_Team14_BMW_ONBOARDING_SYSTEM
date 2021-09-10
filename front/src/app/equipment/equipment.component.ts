
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Equipment } from '../_models';
import { EquipmentService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'equipment.component.html',
    styleUrls: ['./ss_equipment.component.css'] 
})

export class EquipmentComponent implements OnInit {

    equipment: Equipment[] = [];

    searchText;

    constructor(
      private equipmentService: EquipmentService,
      private alertService: AlertService
    ) {
    }

    ngOnInit() { 
      this.loadAll();
  }
  
    private loadAll() {
    this.equipmentService.getEquipmentById(1)
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

    newEquipmentClicked = false;

    updateEquipmentClicked = false;

    newReport_QueryClicked = false;

  color;

  model: any = {};
  model2: any = {};

  addEquipment() {
    this.equipment.push(this.model);
    this.model = {};
  }

  myValue;

  deleteEquipment(i) {
    this.equipment.splice(i,1);
    console.log(i);
  }

  editEquipment(editEquipmentInfo) {
    this.updateEquipmentClicked = !this.updateEquipmentClicked;

    this.model2.equipment_brand = this.equipment[editEquipmentInfo].equipment_brand;
    this.model2.equipment_type = this.equipment[editEquipmentInfo].equipment_type;
    this.model2.equipment_serial_number = this.equipment[editEquipmentInfo].equipment_serial_number;
    this.model2.equipment_trade_in_date = this.equipment[editEquipmentInfo].equipment_trade_in_date;
    this.myValue = editEquipmentInfo;
  }

  editReport_Query(editReport_QueryInfo) {
    this.newReport_QueryClicked = !this.newReport_QueryClicked;

    this.model2.status = this.equipment[editReport_QueryInfo].equipment_query_status;
    this.model2.description = this.equipment[editReport_QueryInfo].equipment_query_description;
    this.myValue = editReport_QueryInfo;
  }

  updateEquipment() {

    let editEquipmentInfo = this.myValue;
    for(let i = 0; i < this.equipment.length; i++) {
      if(i == editEquipmentInfo) {
        this.equipment[i] = this.model2;
        this.model2 = {};
      }
    }
  }

  updateReport_Query() {
    let editReport_QueryInfo = this.myValue;
    for(let i = 0; i < this.equipment.length; i++) {
      if(i == editReport_QueryInfo) {
        this.equipment[i].equipment_query_status = this.model2.status;
        this.equipment[i].equipment_query_description = this.model2.description;
        this.model2 = {};
      }
    }

    this.newReport_QueryClicked = !this.newReport_QueryClicked;
  }

  addNewEquipmentBtn() {
        this.newEquipmentClicked = !this.newEquipmentClicked;
  }

  show: boolean = false;
  public deploymentName: any;
  showModal(){
    this.show = !this.show;
  }
  fnAddDeploytment(){
    alert(this.deploymentName);
  }
  
}