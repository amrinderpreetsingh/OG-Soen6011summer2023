import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { Jobs } from 'src/app/model/jobs';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-list-jobs',
  templateUrl: './list-jobs.component.html',
  styleUrls: ['./list-jobs.component.css']
})

export class ListJobsComponent implements OnInit {
  @ViewChild(MatPaginator) paginator !: MatPaginator;

  constructor(private authService : AuthService, private route : Router) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.list_all_jobs();
  }
  displayedColumns: string[] = ['id', 'userId', 'completed', 'title', 'skills','description'];
  dataSource: any;
  job_data:any = [];
  

  list_all_jobs(){
     this.authService.getJobList().subscribe(res=>{
      console.log(res)
      this.job_data= res;
      this.dataSource = new MatTableDataSource<Jobs>(this.job_data)
      this.dataSource.paginator = this.paginator;
     })
  }

  editJob(id:any){
    console.log("id :", id)
  }

  deleteJob(id:any){
    console.log("id :", id)
  }

  logout(){
    localStorage.clear();
    this.route.navigate(['/']);
   }
}
