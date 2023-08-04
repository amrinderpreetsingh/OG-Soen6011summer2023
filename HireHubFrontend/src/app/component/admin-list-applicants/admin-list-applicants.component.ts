import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-admin-list-applicants',
  templateUrl: './admin-list-applicants.component.html',
  styleUrls: ['./admin-list-applicants.component.css']
})
export class AdminListApplicantsComponent implements OnInit {
  @ViewChild(MatPaginator) paginator !: MatPaginator;
  job_id: string | undefined;
  job_status: any;


  constructor(private authService: AuthService, private route: Router, private router: ActivatedRoute) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.job_id = ''
    this.router.queryParamMap.subscribe(params => {
      const job_id = JSON.parse(params.get('job_id') as string);
      this.job_id = job_id;
      if (job_id !== null) {
        this.getStudentsAppliedForJob(job_id);
      } else {
        this.list_all_students()
      }
    });
  }

  displayedColumns: string[] = ['id', 'name', 'email', 'qualification', 'experience', 'school','status', 'action'];
  dataSource: any;
  student_data: any = [];


  list_all_students() {
    this.authService.getStudentList().subscribe(res => {
      console.log(res);

      console.log(res)
      this.student_data = res;
      this.dataSource = new MatTableDataSource<Student>(this.student_data)
      this.dataSource.paginator = this.paginator;
    })
  }

  getStudentsAppliedForJob(id: string) {
    this.authService.getStudentsAppliedForJob(id).subscribe(res => {
      console.log(res);
      this.student_data = res;
      res.forEach((element: any) => {
        element.jobsApplied.forEach((elem: { jobId: string | undefined; status: any; }) => {
          if (elem.jobId == this.job_id) {
            this.job_status = elem.status;
            element["status"] = elem.status;
          }
        });
      });

      this.student_data.appliedJobs
      this.dataSource = new MatTableDataSource<Student>(this.student_data)
      this.dataSource.paginator = this.paginator;
    })
  }

  logout() {
    localStorage.clear();
    this.route.navigate(['/']);
  }

  applyJob(data: any) {
    this.authService.acceptJob(data.id, this.job_id).subscribe(res => {
      this.ngOnInit();
    })
  }

  declineJob(data: any) {
    this.authService.declineJob(data.id, this.job_id).subscribe(res => {
     this.ngOnInit();
    })
  }

}
