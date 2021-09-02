import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { ResetService } from '@app/_services';

@Component({ templateUrl: 'reset_password.component.html' })

export class Reset_PasswordComponent implements OnInit {
    constructor(
        resetService: ResetService
    ){}

    model: any = {};  

        submit(){
            this.resetService.reset(this.model)
            .pipe(first())
            .subscribe(
                data => {
                },
                error => {
                });
        }

        ngOnInit(){}
}
