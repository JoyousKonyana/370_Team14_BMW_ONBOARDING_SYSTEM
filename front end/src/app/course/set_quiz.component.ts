
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { first } from 'rxjs/operators';

import { Question, Option } from '../_models';
import { QuestionService, AlertService, OptionService } from '../_services';

@Component({ 
    templateUrl: 'set_quiz.component.html',
    styleUrls: ['./ss_course.component.css'] 
})

export class Set_QuizComponent implements OnInit {

  question: Question[] = [];

  ngOnInit() { 
      this.loadAll();
  }

  constructor(
    private questionService: QuestionService,
    private optionService: OptionService,
    private alertService: AlertService
) {

}

  private loadAll() {

    this.questionService.getAllQuestion()
    .pipe(first())
    .subscribe(
      question => {
        this.question = this.question;
      },
      error => {
        this.alertService.error('Error, Data was unsuccesfully retrieved');
      } 
    );

  }

    newCourseClicked = false;

  color;

  //Remove this bad boy
  testData() {
    this.question.push(
      {
        Question_ID:1,
        Question_Type_ID: '6',
        Quiz_ID: 3,
        Question_Category_ID: 4,
        Question_Description:'What is the best car in the world',
        Question_Answer:'2',
        Question_Mark_Allocation: '',
      },
    );
  }

    updateQuestionClicked = false;

    updateOptionClicked = false;

    newQuestionClicked = false;

    newOptionClicked = false;

    setQuizClicked = false;

    quiz = [
      { name: 'Car Quiz', description: '', instructions: ''}
    ];

    questions=[
      {
        id:1,
        question:'What is the best car in the world',
        option:[
          {optionid:1,name:'Mercedes Benz'},
          {optionid:2,name:'BMW'},
          {optionid:3,name:'Audi'},
          {optionid:4,name:'VW'},
        ],
        answer:2,
        selected:0
      },
    ];

  model: any = {};
  model2: any = {}; 
  model3: any ={};

  //Push the set quiz detail to textbox
  pushQuiz() {
    this.setQuizClicked = !this.setQuizClicked;

    this.model3.name = this.quiz[0].name;
    this.model3.description = this.quiz[0].description;
    this.model3.instructions = this.quiz[0].instructions;
  }

  setQuiz(){
    this.quiz[0].name = this.model3.name;
    this.quiz[0].description = this.model3.description;
    this.quiz[0].instructions = this.model3.instructions;

    this.setQuizClicked = !this.setQuizClicked;
  }

  //Add a Question
  addQuestion() {
    this.questions.push(this.model);

    this.model = {};

    this.newQuestionClicked = !this.newQuestionClicked;
  }

  addEmptyOption(i){
    this.myValue2 = i;

    let addOptionsInfo = this.myValue2;

    this.questions[addOptionsInfo].option = [];

    this.questions[addOptionsInfo].option.push(this.model);

    this.model = {};
  }

  //Add a Options
  addOption() {
    let addOptionsInfo = this.myValue2;

    this.questions[addOptionsInfo].option.push(this.model);

    this.model = {};
    
    this.newOptionClicked = !this.newOptionClicked;
  }

  //Delete a question, IT WORKS PERFECTLY
  deleteQuestions(i) {
    this.questions.splice(i,1);
    console.log(i);
  }

  //Delete a options, IT WORKS PERFECTLY
  deleteOption(i, x) {
    this.questions[i].option.splice(x,1);
    console.log(x);
  }

  myValue;
  myValue1;
  myValue2;

  //Edit Questions, pushes data to form to be updated, IT WORKS PERFECTLY
  editQuestions(editQuestionsInfo) {
    this.updateQuestionClicked = !this.updateQuestionClicked;

    this.model2.id = this.questions[editQuestionsInfo].id;
    this.model2.question = this.questions[editQuestionsInfo].question;
    this.model2.answer = this.questions[editQuestionsInfo].answer;
    this.myValue = editQuestionsInfo;
  }

  //Edit Options, pushes data to form to be updated, IT WORKS PERFECTLY
  editOption(editQuestionsInfo, editOptionsInfo) {
    this.updateOptionClicked = !this.updateOptionClicked;

    this.model2.optionid = this.questions[editQuestionsInfo].option[editOptionsInfo].optionid;
    this.model2.name = this.questions[editQuestionsInfo].option[editOptionsInfo].name;
    this.myValue1 = editOptionsInfo;
    this.myValue = editQuestionsInfo;
  }

  //Update Questions, pushes data to localstorage, IT WORKS PERFECTLY
  updateQuestion() {
    let editQuestionsInfo = this.myValue;
    for(let i = 0; i < this.questions.length; i++) {
      if(i == editQuestionsInfo) {
        this.questions[i].id = this.model2.id;
        this.questions[i].question = this.model2.question;
        this.questions[i].answer = this.model2.answer;
        this.model2 = {};
      }
    }
    this.updateQuestionClicked = !this.updateQuestionClicked;
    }

    //Update Option, pushes data to localstorage, IT WORKS PERFECTLY
    updateOption() {
      let editOptionsInfo = this.myValue1;
      let editQuestionsInfo = this.myValue;
      for(let i = 0; i < this.questions.length; i++) {
        for(let x = 0; x < this.questions[editQuestionsInfo].option.length; x++)
        {
          if(i == editQuestionsInfo) {
            if(x == editOptionsInfo){
              this.questions[i].option[x].optionid = this.model2.optionid;
              this.questions[i].option[x].name = this.model2.name;
              this.model2 = {};
            }
          }
        }
      }
      this.updateOptionClicked = !this.updateOptionClicked;
    }

    closeUpdate(){
      this.updateQuestionClicked = !this.updateQuestionClicked;
    }

    closeUpdateOption(){
      this.updateOptionClicked = !this.updateOptionClicked;
    }

    addNewQuestionBtn() {
        this.newQuestionClicked = !this.newQuestionClicked;
    }

    //Open option creation form and store the index of the Options from the question
    addNewOptionBtn(i) {
      this.myValue2 = i;

      this.newOptionClicked = !this.newOptionClicked;
  }

}