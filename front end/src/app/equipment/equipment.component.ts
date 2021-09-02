
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User, Equipment, Query_Status } from '../_models';
import { Query_StatusService, EquipmentService, AlertService } from '../_services';

@Component({ 
    templateUrl: 'equipment.component.html',
    styleUrls: ['./ss_equipment.component.css'] 
})

export class EquipmentComponent implements OnInit {

    currentUser: User;
    currentUserSubscription: Subscription;
    equipment: Equipment[] = [];
    query_status: Query_Status[] =[];

    searchText;

    constructor(
      private equipmentService: EquipmentService,
      private query_statusService: Query_StatusService,
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

  private loadQuery(i) {
    this.query_statusService.getQuery_StatusById(i)
    .pipe(first())
    .subscribe(
      query_status => {
        this.query_status = query_status;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newEquipmentClicked = false;

    updateEquipmentClicked = false;

    newReport_QueryClicked = false;

  equipment_type = [
    { name: 'Laptop' },
    { name: 'Phone' },
    { name: 'Tablet' },
    { name: 'Computer' },
  ];

  equipment_brand = [
    { name: 'Apple' },
    { name: 'Samsung' },
    { name: 'Sony' },
  ];

  equipment = [
    { 
      id: '111',
      equipment_trade_in_date: '29 May 2019', 
      equipment_serial_number: '098423',
      equipment_brand: 'Acer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '222',
      equipment_trade_in_date: '12 June 2020', 
      equipment_serial_number: '894023',
      equipment_brand: 'Mercer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '333',
      equipment_trade_in_date: '29 May 2019', 
      equipment_serial_number: '098423',
      equipment_brand: 'Acer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '444',
      equipment_trade_in_date: '12 June 2020', 
      equipment_serial_number: '894023',
      equipment_brand: 'Mercer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '555',
      equipment_trade_in_date: '29 May 2019', 
      equipment_serial_number: '098423',
      equipment_brand: 'Acer',
      equipment_query_status: '', equipment_query_description: ''    },
    { 
      id: '666',
      equipment_trade_in_date: '12 June 2020', 
      equipment_serial_number: '894023',
      equipment_brand: 'Mercer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '777',
      equipment_trade_in_date: '29 May 2019', 
      equipment_serial_number: '098423',
      equipment_brand: 'Acer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
    { 
      id: '888',
      equipment_trade_in_date: '12 June 2020', 
      equipment_serial_number: '894023',
      equipment_brand: 'Mercer',
      equipment_type: 'Laptop',
      equipment_query_status: '', equipment_query_description: ''
    },
  ];

  color;

  model: any = {};
  model2: any = {};

  addEquipment() {
    if(Object.keys(this.model).length < 2)
    {
      this.alertService.error("Error, you have an empty feild");
      console.log('Empty');
      this.model = {};
    }
    else if((Object.keys(this.model).length==2))
    {
      this.equipmentService.create(this.model)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Creation was successful', true);
                    this.model = {};
                },
                error => {
                    this.alertService.error('Error, Creation was unsuccesful');
                });
    }
  }

  myValue;

  deleteEquipment(i) {
    this.equipmentService.delete(i)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Deletion was successful', true);

                    this.equipment.splice(i, 1);
                    console.log(i);
                },
                error => {
                    this.alertService.error('Error, Deletion was unsuccesful');
                });
  }

  editEquipment(editEquipmentInfo) {
    this.updateEquipmentClicked = !this.updateEquipmentClicked;

    this.model2.equipment_brand = this.equipment[editEquipmentInfo].Equipment_Brand;
    this.model2.equipment_type = this.equipment[editEquipmentInfo].Equipment_Type_ID;
    this.model2.equipment_serial_number = this.equipment[editEquipmentInfo].Serial_Number;
    this.model2.equipment_trade_in_date = this.equipment[editEquipmentInfo].Equpment_Trade_In_Date;
    this.myValue = editEquipmentInfo;
  }

  editReport_Query(editReport_QueryInfo) {
    this.newReport_QueryClicked = !this.newReport_QueryClicked;

    this.loadQuery(editReport_QueryInfo)
     this.model2.status= this.query_status[editReport_QueryInfo].Equipment_Query_Status_ID;
        this.model2.description=this.query_status[editReport_QueryInfo].Equipment_Query_Description;
    this.myValue = editReport_QueryInfo;
  }

  updateEquipment() {

    let editEquipmentInfo = this.myValue;

    for(let i = 0; i < this.equipment.length; i++) {

      if(i == editEquipmentInfo) 
      {
        this.equipmentService.update(editEquipmentInfo, this.model2)
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
    let editEquipmentInfo = this.myValue;

    for(let i = 0; i < this.equipment.length; i++) {

      if(i == editEquipmentInfo) 
      {
        this.query_statusService.update(editEquipmentInfo, this.model2)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update was successful', true);
                },
                error => {
                    this.alertService.error('Error, Update was unsuccesful');
                });
      }
    }
    }

   // this.newReport_QueryClicked = !this.newReport_QueryClicked;
 // }

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