import { Component, OnInit } from '@angular/core';
import { PostJobs } from 'src/app/model/post-jobs';

@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css']
})
export class PostJobComponent implements OnInit {
  jobTitle : string = '';
  skills : string = '';
  roles : string = '';
  experience : string=''
  jobType : string='';
  description : string='';
  id: number|undefined ;
  postedBy: any;
  jobTypes: string[]
  experiences:number[]

  postJobs : PostJobs = new PostJobs();

  constructor() { 
    this.jobTypes = ['Internship', 'Contract', 'Full Time', 'Part Time'];
    this.experiences = [0,1,2,3,4,5,6,7,8]
  }
  isExpanded: boolean = false;

  ngOnInit(): void {
    this.jobTitle = '';
    this.skills = '';
    this.roles='';
    this.experience='';
    this.jobType='';
    this.description='';
    this.id = undefined;
    localStorage.setItem('user','jobposter@poster.com')
  }
 submit_job(){
 this.postJobs.id= this.id;
 this.postJobs.postedBy = localStorage.getItem('user');
 this.postJobs.description = this.description;
 this.postJobs.experience = this.experience;
 this.postJobs.role = this.roles;
 this.postJobs.title= this.jobTitle;
 this.postJobs.skills = this.skills;
 this.postJobs.type = this.jobType;
 console.log(this.postJobs)


}
}

