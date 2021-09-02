import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { ViewChild, ElementRef } from "@angular/core";

//Install it first
//import {jsPDF} from "jspdf";

import { User, Onboarder, Certificate } from '../_models';
import { UserService, OnboarderService, CertificateService, AlertService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'report.component.html',
    styleUrls: ['./ss_report.component.css']
})
export class ReportComponent implements OnInit {
    onboarder: Onboarder[] = [];
    certificate: Certificate[] = [];

  constructor(
      private onboarderService: OnboarderService,
      private certificateService: CertificateService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAllOnboarder();
      this.loadAllCertificate();
  }

  private loadAllCertificate() {
    this.certificateService.getCertificateById()
    .pipe(first())
    .subscribe(
      certificate => {
        this.certificate = certificate;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

  private loadAllOnboarder() {
    this.onboarderService.getAllOnboarder()
    .pipe(first())
    .subscribe(
      onboarder => {
        this.onboarder = onboarder;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

}