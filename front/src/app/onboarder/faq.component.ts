import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User, FAQ } from '../_models';
import { FAQService, AlertService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'faq.component.html',
    styleUrls: ['./ss_onboarder.component.css']
})
export class FAQComponent implements OnInit {
  dataSaved = false;  
  faqForm: any;
  faq: FAQ[] = [];

  faqIdUpdate = null;  
  massage = null;

  constructor(
      private faqService: FAQService,
      private alertService: AlertService
  ) {

  }

  ngOnInit() { 
      this.loadAllFAQ();
  }

  

  private loadAllFAQ() {
    this.faqService.getAllFAQ()
    .pipe(first())
    .subscribe(
      faq => {
        //this.faq = faq;
        this.faq = faq;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );
  }

    newFAQClicked = false;

  color;

  model: any = {};
  model2: any = {}; 

  //Remove this bad boy
  testData() {
    this.faq.push(
      { Faqid: 1, Faqdescription: 'Where is x page', Faqanswer: 'In y page'},
      { Faqid: 2, Faqdescription: 'Where is y page', Faqanswer: 'In x page'},
      { Faqid: 3, Faqdescription: 'What is z', Faqanswer: 'It is Z'},
      { Faqid: 4, Faqdescription: 'When is q', Faqanswer: 'It is Q'},
    )
  }

}