import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employer } from '../model/employer.model';
import { Student } from '../model/student.model';
import { Jobs } from '../model/jobs';
import { PostJobs } from '../model/post-jobs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loginUrl : string = '';
  signUpUrl : string = '';
  url:string='';
  postJobUrl:string=' '

  constructor(private http : HttpClient) {

    this.loginUrl = "http://localhost:5001/employer/login";
    this.signUpUrl = "http://localhost:5001/employer/signup";
    this.url= "https://jsonplaceholder.typicode.com/todos";
    this.postJobUrl = "ttp://localhost:5001/employer/postjob"


  }

  login_student(student :Student) : Observable<any> {
    console.log(student)
    return this.http.post<any>(this.loginUrl,student);
  }

  login_employer(employer :Employer) : Observable<any> {
    console.log(employer)
    return this.http.get<any>(this.loginUrl+"?email="+employer.companyEmail+"&password="+employer.companyPassword);
  }

  signUp_student(student : Student) : Observable<any> {
    console.log(student)
    return this.http.post<any>(this.signUpUrl,student);
  }

  signUp_employer(employer : Employer) : Observable<any> {
    console.log(employer)
    return this.http.post<any>(this.signUpUrl,employer);
  }

  get_job_list():Observable<any>{
    return this.http.get<Jobs>(this.url)
  }

post_jobs(job : PostJobs) : Observable<any> {
    console.log(job)
    return this.http.post<any>(this.postJobUrl,job);
  }
}
