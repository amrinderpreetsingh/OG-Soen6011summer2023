import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AdminDashboardComponent } from './component/admin-dashboard/admin-dashboard.component';
import { AdminListEmployerComponent } from './component/admin-list-employer/admin-list-employer.component';
import { AdminListJobsComponent } from './component/admin-list-jobs/admin-list-jobs.component';
import { AdminListStudentComponent } from './component/admin-list-student/admin-list-student.component';
import { EmployerDashboardComponent } from './component/employer-dashboard/employer-dashboard.component';
import { ListJobsComponent } from './component/list-jobs/list-jobs.component';
import { ListStudentComponent } from './component/list-student/list-student.component';
import { PostJobComponent } from './component/post-job/post-job.component';
import { StudentDashboardComponent } from './component/student-dashboard/student-dashboard.component';
import { StudentJobsComponent } from './component/student-jobs/student-jobs.component';


const routes: Routes = [
  {path:'', component: LoginComponent},
  {path:'signup', component: SignupComponent},
  {path:'Student', component:StudentDashboardComponent},
  {path:'Employer',component:EmployerDashboardComponent},
  {path:'employer/list-job', component: ListJobsComponent},
  {path:'employer/post-job',component:PostJobComponent},
  {path:'employer/list-student', component:ListStudentComponent},
  {path:'student/student-jobs', component:StudentJobsComponent},
  {path:"admin-dashboard",component:AdminDashboardComponent},
  {path:"admin/list-job", component: AdminListJobsComponent},
  {path:"admin/list-student",component:AdminListStudentComponent},
  {path:"admin/list-employer",component:AdminListEmployerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
