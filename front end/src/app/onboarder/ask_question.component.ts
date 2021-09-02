import { DatePipe } from '@angular/common';
import {
  AfterViewChecked,
  Component,
  ElementRef,
  OnInit,
  ViewChild
} from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-chat-room',
  templateUrl: './ask_question.component.html',
  styleUrls: ['./robot.component.css']
})
export class Ask_QuestionComponent implements OnInit {

  constructor() {
  }

  ngOnInit() {
  }
}
