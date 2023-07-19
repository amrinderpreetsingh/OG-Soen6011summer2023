import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Jobs } from 'src/app/model/jobs';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-student-jobs',
  templateUrl: './student-jobs.component.html',
  styleUrls: ['./student-jobs.component.css']
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
     console.log(res)
     this.job_data= res;
     this.dataSource = new MatTableDataSource<Jobs>(this.job_data)
     this.dataSource.paginator = this.paginator;
    })
 }
 logout(){
  localStorage.clear();
  this.route.navigate(['/']);
 }
}
