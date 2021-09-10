import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home';
import { AdminComponent } from './admin';
import { LoginComponent } from './login';
import { AuthGuard } from './_helpers';
import { Role } from './_models';

import { 
    Assign_User_RoleComponent,
    User_RoleComponent,
    SS_UsersComponent
 } from './users';

 import {
   Register_EmployeeComponent,
    Assign_EquipmentComponent,
    OnboarderComponent,
    SS_AdministratorComponent,
    CRUD_FAQComponent,
    Import_EmployeeComponent
 } from './administrator';

 import {
    Take_CourseComponent,
    Take_Learning_OutcomeComponent,
    Take_QuizComponent,
    Take_ContentComponent,
    ProgressComponent,
    Ask_QuestionComponent,
    FAQComponent,
    SS_OnboarderComponent
 } from './onboarder';

 import {
    CourseComponent, 
    Assign_CourseComponent,
    Learning_OutcomeComponent,
    Set_QuizComponent,
    Learning_ContentComponent,
    CRUD_AchievementComponent,
    SS_CourseComponent,
 } from './course';

 import {
    SS_EquipmentComponent,
    EquipmentComponent,
    My_EquipmentComponent,
 } from './equipment';
 
 import {
    SS_ReportComponent,
    ReportComponent,
 } from './report';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'admin',
        component: AdminComponent,
        canActivate: [AuthGuard],
        data: { roles: [Role.Admin] }
    },
    {
        path: 'login',
        component: LoginComponent
    },

    //Users path pages
    { path: 'ss_users', component: SS_UsersComponent, canActivate: [AuthGuard] },
    { path: 'assign_user_role', component: Assign_User_RoleComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'user_role', component: User_RoleComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },

    //Administrator path pages
    { path: 'onboarder', component: OnboarderComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'register_employee', component: Register_EmployeeComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'ss_administrator', component: SS_AdministratorComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'assign_equipment', component: Assign_EquipmentComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'crud_faq', component: CRUD_FAQComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'import_employee', component: Import_EmployeeComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },

    //Report path pages
    { path: 'ss_report', component: SS_ReportComponent, canActivate: [AuthGuard] },
    { path: 'report', component: ReportComponent, canActivate: [AuthGuard] },
    

    //Onboarder path pages
    { path: 'ss_onboarder', component: SS_OnboarderComponent, canActivate: [AuthGuard] },
    { path: 'take_course', component: Take_CourseComponent, canActivate: [AuthGuard] },
    { path: 'faq', component: FAQComponent, canActivate: [AuthGuard] },
    { path: 'take_learning_outcome/:id',  component: Take_Learning_OutcomeComponent,canActivate: [AuthGuard] },
    { path: 'take_quiz/:id', component: Take_QuizComponent, canActivate: [AuthGuard] },
    { path: 'take_content/:id', component: Take_ContentComponent, canActivate: [AuthGuard] },
    { path: 'progress', component: ProgressComponent, canActivate: [AuthGuard] },
    { path: 'ask_question', component: Ask_QuestionComponent, canActivate: [AuthGuard] },

    //Course path pages
    { path: 'ss_course', component: SS_CourseComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'course', component: CourseComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'assign_course', component: Assign_CourseComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'learning_outcome/:id', component: Learning_OutcomeComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'learning_content/:id', component: Learning_ContentComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'set_quiz/:id', component: Set_QuizComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },
    { path: 'crud_achievement', component: CRUD_AchievementComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin] } },

    //Equipment path pages
    { path: 'ss_equipment', component: SS_EquipmentComponent, canActivate: [AuthGuard] },
    { path: 'equipment', component: EquipmentComponent, canActivate: [AuthGuard] },
    { path: 'my_equipment', component: My_EquipmentComponent, canActivate: [AuthGuard] },


    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
