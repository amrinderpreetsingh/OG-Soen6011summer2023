import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Jobs } from 'src/app/model/jobs';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-student-jobs',
  templateUrl: './student-jobs.component.html',
  styleUrls: ['./student-jobs.component.css'],
})
export class StudentJobsComponent implements OnInit {

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  constructor(private authService : AuthService, private route : Router) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.listAllJobs()
  }
  displayedColumns: string[] = ['id', 'title', 'skills', 'role', 'type','experience','description','postedBy'];
  dataSource: any;
  job_data:any = [];
  

  listAllJobs(){
    this.authService.getAllJobs().subscribe(res=>{
      this.job_data = res.map((job: Jobs) => {
      const companyName = this.extractDomainFromEmail(job.postedBy);
      return { ...job, companyName: companyName };
    })
    console.log(this.job_data);
    
 })}

 extractDomainFromEmail(email: string): string {
  const atIndex = email.indexOf('@');
  const dotIndex = email.lastIndexOf('.');
  
  if (atIndex !== -1 && dotIndex !== -1 && dotIndex > atIndex) {
    const domain = email.slice(atIndex + 1, dotIndex);
    return domain.charAt(0).toUpperCase() + domain.slice(1);
  }
  
  return '';
}
apply_job(data:any){
  console.log(data);
  
}
 logout(){
  localStorage.clear();
  this.route.navigate(['/']);
 }
}
