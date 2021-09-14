import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Equipment, Equipment_Brand, Equipment_Type } from '../_models';
import { EquipmentService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'equipment.component.html',
    styleUrls: ['./ss_equipment.component.css'] 
})

export class EquipmentComponent implements OnInit {
    equipment: Equipment[] = [];
    types: Equipment_Type[] = [];
    brands: Equipment_Brand[] = [];

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

    this.equipmentService.getAllEquipment()
    .pipe(first())
    .subscribe(
      equipment => {
        this.equipment = equipment;
      },
      error => {
        this.alertService.error('Error, Data (Equipment) was unsuccesfully retrieved');
      } 
    );

    this.equipmentService.getAllEquipment_Brand()
    .pipe(first())
    .subscribe(
      brands => {
        this.brands = brands;
      },
      error => {
        this.alertService.error('Error, Data (Equipment Brand) was unsuccesfully retrieved');
      } 
    );

    this.equipmentService.getAllEquipment_Type()
    .pipe(first())
    .subscribe(
      types => {
        this.types = types;
      },
      error => {
        this.alertService.error('Error, Data (Equipment Type) was unsuccesfully retrieved');
      } 
    );

  }

    newEquipmentClicked = false;

    updateEquipmentClicked = false;

    newReport_QueryClicked = false;

  model: any = {};
  model2: any = {};

  model3:Equipment = {
    EquipmentId: 1, 
    EquipmentTypeId : 1, 
    EquipmentTradeInStatus: '',
    WarrantyStartDate: '',
    WarrantyEndDate: '',
    WarrantyStatus: '',
    EquipmentTradeInDeadline: '', 
    EquipmentBrandId: 1,
    EquipmentSerialNumber : 1, 
  };

  type(index) {
    this.model.EquipmentTypeId = index;
    this.model2.EquipmentTypeId = index;
  }

  brand(index) {
    this.model.EquipmentBrandId = index;
    this.model2.EquipmentBrandId = index;
  }

  addEquipment() {
    this.model3.EquipmentTypeId = this.model.Equipment_Type_ID;
    this.model3.EquipmentTradeInStatus = this.model.EquipmentTradeInStatus;
    this.model3.WarrantyStartDate = this.model.WarrantyStartDate;
    this.model3.WarrantyEndDate = this.model.WarrantyEndDate;
    this.model3.WarrantyStatus = this.model.WarrantyStatus;
    this.model3.EquipmentTradeInDeadline = this.model.EquipmentTradeInDeadline;
    this.model3.EquipmentBrandId = this.model.EquipmentBrandId;
    this.model3.EquipmentSerialNumber = this.model.EquipmentSerialNumber;

    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.newEquipmentClicked = !this.newEquipmentClicked;
      this.model = {};
    }
    else if((Object.keys(this.model).length==2))
    {
      this.equipmentService.create(this.model3)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.equipment.push(this.model3);
                    this.newEquipmentClicked = !this.newEquipmentClicked;
                    this.model = {};
                },
                error => {
                  this.alertService.error('Error, Creation was unsuccesful');
              });
    }
  }

  myValue;

  deleteEquipment(i) {
    this.equipmentService.delete(i+1)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);
                    this.equipment.splice(i, 1);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                });
  }

  editEquipment(editEquipmentInfo) {
    this.updateEquipmentClicked = !this.updateEquipmentClicked;

    this.model2.EquipmentTradeInStatus = this.equipment[editEquipmentInfo].EquipmentTradeInStatus;
    this.model2.EquipmentTradeInDeadline = this.equipment[editEquipmentInfo].EquipmentTradeInDeadline;
    this.model3.WarrantyStartDate = this.equipment[editEquipmentInfo].WarrantyStartDate;
    this.model3.WarrantyEndDate = this.equipment[editEquipmentInfo].WarrantyEndDate;
    this.model3.WarrantyStatus = this.equipment[editEquipmentInfo].WarrantyStatus;
    this.model2.EquipmentSerialNumber = this.equipment[editEquipmentInfo].EquipmentSerialNumber;

    this.myValue = editEquipmentInfo;
  }

  editReport_Query(editReport_QueryInfo) {
    this.newReport_QueryClicked = !this.newReport_QueryClicked;

    // this.model2.status = this.equipment[editReport_QueryInfo].equipment_query_status;
    // this.model2.description = this.equipment[editReport_QueryInfo].equipment_query_description;
    this.myValue = editReport_QueryInfo;
  }

  updateEquipment() {
    let editEquipmentInfo = this.myValue;

    this.model3.EquipmentTypeId = this.model2.Equipment_Type_ID;
    this.model3.EquipmentTradeInStatus = this.model2.EquipmentTradeInStatus;
    this.model3.WarrantyStartDate = this.model2.WarrantyStartDate;
    this.model3.WarrantyEndDate = this.model2.WarrantyEndDate;
    this.model3.WarrantyStatus = this.model2.WarrantyStatus;
    this.model3.EquipmentTradeInDeadline = this.model2.EquipmentTradeInDeadline;
    this.model3.EquipmentBrandId = this.model2.EquipmentBrandId;
    this.model3.EquipmentSerialNumber = this.model2.EquipmentSerialNumber;

    for(let i = 0; i < this.equipment.length; i++) {

      if(i == editEquipmentInfo) 
      {
        this.equipmentService.update(this.equipment[editEquipmentInfo].EquipmentId, this.model3)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);
                    this.equipment[i] = this.model2;
                    this.model2 = {};
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                });
      }
    }
  }

  updateReport_Query() {
    let editReport_QueryInfo = this.myValue;
    for(let i = 0; i < this.equipment.length; i++) {
      if(i == editReport_QueryInfo) {
        // this.equipment[i].equipment_query_status = this.model2.status;
        // this.equipment[i].equipment_query_description = this.model2.description;
        this.model2 = {};
      }
    }

    this.newReport_QueryClicked = !this.newReport_QueryClicked;
  }

  addNewEquipmentBtn() {
        this.newEquipmentClicked = !this.newEquipmentClicked;
  }
  
}