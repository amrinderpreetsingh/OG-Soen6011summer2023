import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Jobs } from 'src/app/model/jobs';
import { AuthService } from 'src/app/service/auth.service';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-student-dashboard',
  templateUrl: './student-dashboard.component.html',
  styleUrls: ['./student-dashboard.component.css']
})
export class StudentDashboardComponent implements OnInit {

  constructor(private authService: AuthService,private route:Router) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.listAllJobs()
  }

  job_data: any = [];

  listAllJobs() {
    this.authService.getAllJobs().subscribe(res => {
      this.job_data = res.map((job: Jobs) => {
        const companyName = this.extractDomainFromEmail(job.postedBy);
        return { ...job, companyName: companyName };
      })
      console.log(this.job_data);
    })
  }

  extractDomainFromEmail(email: string): string {
    const atIndex = email.indexOf('@');
    const dotIndex = email.lastIndexOf('.');

    if (atIndex !== -1 && dotIndex !== -1 && dotIndex > atIndex) {
      const domain = email.slice(atIndex + 1, dotIndex);
      return domain.charAt(0).toUpperCase() + domain.slice(1);
    }

    return '';
  }
  
  apply_job(data: any) {
    console.log(data.id);
    
  this.authService.applyJob(data.id).subscribe(res=>{
    Swal.fire('Thank you...', 'Job applied succesfully!', 'success');
    this.listAllJobs();
  })

}

  logout(){
    localStorage.clear();
    this.route.navigate(['/']);
   }
}
