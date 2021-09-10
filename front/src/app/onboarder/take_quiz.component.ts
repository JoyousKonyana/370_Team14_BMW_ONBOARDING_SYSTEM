import { Component } from '@angular/core';

@Component({
  templateUrl: './take_quiz.component.html',
  styleUrls: [ './ss_onboarder.component.css' ]
})
export class Take_QuizComponent  {
  
 questions:any;
 currentIndex:number;
 notAttempted:any;
 correct:any;
 currentQuestionSet:any;
 start=false;
 gameover=false;
 buttonname="Start Quiz";
 constructor(){

   //Creating summy questions Json dta
   this.questions=[
     {
       id:1,
       question:'What is the best car in the world?',
       option:[
         {optionid:1,name:'Audi'},
         {optionid:2,name:'BMW'},
         {optionid:3,name:'Tesla'},
         {optionid:4,name:'Mercedes Benz'}
       ],
       answer:2,
       selected:0
     },
     {
       id:2,
       question:'Show you be racist?',
       option:[
         {optionid:1,name:'No'},
         {optionid:2,name:'YESS!'},
         {optionid:3,name:'Maybe'},
         {optionid:4,name:'Sometimes'}
       ],
       answer:1,
       selected:0
     },
     {
       id:3,
       question:'Should you be rude?',
       option:[
         {optionid:1,name:'YESS!'},
         {optionid:2,name:'No'},
         {optionid:3,name:'Maybe'},
         {optionid:4,name:'All the time'}
       ],
       answer:2,
       selected:0
     },
     {
       id:4,
       question:'Where will you find the cat?',
       option:[
         {optionid:1,name:'In the roof'},
         {optionid:2,name:'In the ceiling'},
         {optionid:3,name:'In the BMW'},
         {optionid:4,name:'In pool'}
       ],
       answer:3,
       selected:0
     }
   ];

   this.currentIndex=0;
   this.currentQuestionSet= this.questions[this.currentIndex];
 }
  
  next(){
    this.currentIndex = this.currentIndex + 1;
    this.currentQuestionSet= this.questions[this.currentIndex];
  }
  submit(){
    this.buttonname="Retry";
    if(this.currentIndex+1==this.questions.length){
       this.gameover=true;
       this.start=false;
         this.correct=0;
    this.notAttempted=0;
    this.questions.map(x=>{
        if(x.selected!=0){
          if(x.selected == x.answer)
            this.correct=this.correct + 1;
        }
        else{
          this.notAttempted=this.notAttempted + 1;
        }
        x.selected=0;
    });
    }
    
  
  }
  startQuiz(){
    this.gameover=false;
    this.currentIndex=0;
   this.currentQuestionSet= this.questions[this.currentIndex];
      this.start=true;
  }
}