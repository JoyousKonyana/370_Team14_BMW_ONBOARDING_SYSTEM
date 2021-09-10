import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';

@Component({ 
    templateUrl: 'learning_content.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class Learning_ContentComponent implements OnInit {

    currentUser: User;
    currentUserSubscription: Subscription;
    users: User[] = [];

    constructor(

    ) {
    }

    ngOnInit() {
      this.model3.title = this.learning_content[0].title;
      this.model3.youtube = this.learning_content[0].youtube;
      this.model3.content = this.learning_content[0].content;
    }

    learning_content = [
      {
        title: '',
        youtube: '',
        content: ''
      }
    ];

  color;

  model3: any = {}; 
  
  myValue;

  setQuiz(){
    this.learning_content[0].title = this.model3.title;
    this.learning_content[0].youtube = this.model3.youtube;
    this.learning_content[0].content = this.model3.content;
  }

}