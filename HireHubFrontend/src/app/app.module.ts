import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AdminDashboardComponent } from './component/admin-dashboard/admin-dashboard.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { StudentDashboardComponent } from './component/student-dashboard/student-dashboard.component';
import { EmployerDashboardComponent } from './component/employer-dashboard/employer-dashboard.component';
import {MatListModule} from '@angular/material/list';
import { ListJobsComponent } from './component/list-jobs/list-jobs.component';
import { PostJobComponent } from './component/post-job/post-job.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { ListStudentComponent } from './component/list-student/list-student.component';
import { StudentJobsComponent } from './component/student-jobs/student-jobs.component';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { AdminListStudentComponent } from './component/admin-list-student/admin-list-student.component';
import { AdminListJobsComponent } from './component/admin-list-jobs/admin-list-jobs.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditJobFormComponent } from './component/edit-job-form/edit-job-form.component';
import {MatDialogModule} from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { EditStudentFormComponent } from './component/edit-student-form/edit-student-form.component';
import { EditEmployerFormComponent } from './component/edit-employer-form/edit-employer-form.component';
import { AdminListEmployerComponent } from './component/admin-list-employer/admin-list-employer.component';
import { AdminListApplicantsComponent } from './component/admin-list-applicants/admin-list-applicants.component';




@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    AdminDashboardComponent,
    StudentDashboardComponent,
    EmployerDashboardComponent,
    ListJobsComponent,
    PostJobComponent,
    ListStudentComponent,
    StudentJobsComponent,
    AdminListStudentComponent,
    AdminListJobsComponent,
    EditJobFormComponent,
    EditStudentFormComponent,
    EditEmployerFormComponent,
    AdminListEmployerComponent,
    AdminListApplicantsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatSlideToggleModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,  
    MatSidenavModule,
    MatListModule,
    NoopAnimationsModule,
    MatFormFieldModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCardModule,
    MatExpansionModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
