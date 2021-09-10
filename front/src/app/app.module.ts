import { AlertComponent } from './_component/alert.component';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

// used to create fake backend
import { fakeBackendProvider } from './_helpers';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';

// import { AlertComponent } from './_component';

import {
    Register_EmployeeComponent,
    Assign_EquipmentComponent,
    OnboarderComponent,
    SS_AdministratorComponent,
    CRUD_FAQComponent,
    CRUD_EmployeeComponent,
    Import_EmployeeComponent,
 } from './administrator';

 import {
    CourseComponent, 
    Assign_CourseComponent,
    Learning_OutcomeComponent,
    Set_QuizComponent,
    Learning_ContentComponent,
    SS_CourseComponent,
    CRUD_AchievementComponent,
 } from './course';

 import {
    SS_EquipmentComponent,
    EquipmentComponent, 
    My_EquipmentComponent
} from './equipment';

import {
    Take_CourseComponent,
    Take_Learning_OutcomeComponent,
    Take_QuizComponent,
    Take_ContentComponent,
    ProgressComponent,
    FAQComponent,
    Ask_QuestionComponent,
    SS_OnboarderComponent
 } from './onboarder';

 import { 
    Assign_User_RoleComponent,
    User_RoleComponent,
    SS_UsersComponent
 } from './users';

 import {
    SS_ReportComponent,
    ReportComponent
} from './report';

//extra Features
import { FormsModule } from '@angular/forms';
// search module
import { Ng2SearchPipeModule } from 'ng2-search-filter';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
        FormsModule,
        //Ng2SearchPipeModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        AdminComponent,
        LoginComponent,
        AlertComponent,

        //Report
        SS_ReportComponent,
        ReportComponent,

        //Users
        SS_UsersComponent,
        User_RoleComponent,
        Assign_User_RoleComponent,

        //Administrator
        SS_AdministratorComponent,
        Register_EmployeeComponent,
        OnboarderComponent,
        Assign_EquipmentComponent,
        CRUD_FAQComponent,
        Import_EmployeeComponent,

        //Course 
        CourseComponent,
        SS_CourseComponent,
        CourseComponent,
        Assign_CourseComponent,
        Set_QuizComponent,
        Learning_OutcomeComponent,
        Learning_ContentComponent,
        CRUD_AchievementComponent,

        //Equipment
        SS_EquipmentComponent,
        EquipmentComponent,
        My_EquipmentComponent,

        //Onboarder
        SS_OnboarderComponent,
        Take_CourseComponent,
        Take_Learning_OutcomeComponent,
        Take_QuizComponent,
        Take_ContentComponent,
        FAQComponent,
        ProgressComponent,
        Ask_QuestionComponent,
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

        // provider used to create fake backend
        fakeBackendProvider
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }