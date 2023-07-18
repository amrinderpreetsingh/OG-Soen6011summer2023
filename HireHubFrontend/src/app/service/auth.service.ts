import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employer } from '../model/employer.model';
import { Student } from '../model/student.model';
import { Jobs } from '../model/jobs';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  employerLoginUrl : string = '';
  studentLoginUrl : string = '';
  employerSignUpUrl : string = '';
  studentSignUpUrl : string = '';
  url:string='';
  postJobUrl:string=' '
  getJobsUrl:string=' '
  getStudentUrl:string=''

  constructor(private http : HttpClient) {

    this.employerLoginUrl = "http://localhost:5001/employer/login";
    this.employerSignUpUrl = "http://localhost:5001/employer/signup";
    this.url= "https://jsonplaceholder.typicode.com/todos";
    this.postJobUrl = "http://localhost:5001/employer/postjob"
    this.getJobsUrl="http://localhost:5001/employer/getjobs";
    this.studentSignUpUrl="http://localhost:5001/student/signup"
    this.studentLoginUrl="http://localhost:5001/student/login"
    this.getStudentUrl= "http://localhost:5001/employer/getstudents"
  }

  login_student(student :Student) : Observable<any> {
    console.log(student)
    return this.http.get<any>(this.studentLoginUrl+"?email="+student.email+"&password="+student.password);
  }

  login_employer(employer :Employer) : Observable<any> {
    console.log(employer)
    return this.http.get<any>(this.employerLoginUrl+"?email="+employer.companyEmail+"&password="+employer.companyPassword);
  }

  signUp_student(student : Student) : Observable<any> {
    console.log(student)
    return this.http.post<any>(this.studentSignUpUrl,student);
  }

  signUp_employer(employer : Employer) : Observable<any> {
    console.log(employer)
    return this.http.post<any>(this.employerSignUpUrl,employer);
  }

  get_job_list():Observable<any>{
    return this.http.get<Jobs>(this.getJobsUrl+"?email=jobs@nagarro.com")
  }

  post_jobs(job:Jobs):Observable<any>{
    return this.http.post(this.postJobUrl,job)
  }

  get_student_list():Observable<any>{
    return this.http.get<Student>(this.getStudentUrl)
  }
}
