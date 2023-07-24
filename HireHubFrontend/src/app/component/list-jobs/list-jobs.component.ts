import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { Jobs } from 'src/app/model/jobs';
import { MatTableDataSource } from '@angular/material/table';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-list-jobs',
  templateUrl: './list-jobs.component.html',
  styleUrls: ['./list-jobs.component.css']
})

export class ListJobsComponent implements OnInit {
  @ViewChild(MatPaginator) paginator !: MatPaginator;

  constructor(private authService: AuthService, private route: Router, private router: ActivatedRoute) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.list_all_jobs();
  }
  displayedColumns: string[] = ['id', 'userId', 'completed', 'title', 'skills', 'description', 'action'];
  dataSource: any;
  job_data: any = [];


  list_all_jobs() {
    this.authService.getJobsPostedByAnEmployer().subscribe(res => {
      console.log(res)
      this.job_data = res;
      this.dataSource = new MatTableDataSource<Jobs>(this.job_data)
      this.dataSource.paginator = this.paginator;
    })
  }

  editJob(id: any) {
    console.log("id :", id)
  }

  openComponentInNewTab(data: any) {
    const componentRoute = '/list-student';
    const queryParams = { job_id: data.id };
    const url = this.route.createUrlTree([componentRoute], { queryParams: queryParams }).toString();
    window.open(url, '_blank');
  }

  logout() {
    localStorage.clear();
    this.route.navigate(['/']);
  }

  deleteJob(id: any) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You are about to delete this item!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.authService.deleteJobEmployer(id).subscribe(res => {
          console.log(res);
          this.list_all_jobs();
        });
        Swal.fire({
          title: 'Deleted!',
          text: 'The item has been deleted.',
          icon: 'success',
        });
      }
    });
  }
}
