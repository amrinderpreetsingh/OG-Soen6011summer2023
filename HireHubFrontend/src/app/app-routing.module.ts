import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AdminDashboardComponent } from './component/admin-dashboard/admin-dashboard.component';
import { EmployerDashboardComponent } from './component/employer-dashboard/employer-dashboard.component';
import { ListJobsComponent } from './component/list-jobs/list-jobs.component';
import { PostJobComponent } from './component/post-job/post-job.component';
import { StudentDashboardComponent } from './component/student-dashboard/student-dashboard.component';


const routes: Routes = [
  {path:'', component: LoginComponent},
  {path:'signup', component: SignupComponent},
  {path:'Student', component:StudentDashboardComponent},
  {path:'Employer',component:EmployerDashboardComponent},
  {path:'list-job', component: ListJobsComponent},
  {path:'post-job',component:PostJobComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }