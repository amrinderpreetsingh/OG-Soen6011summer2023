import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employer } from '../model/employer.model';
import { Student } from '../model/student.model';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loginUrl : string = '';
  signUpUrl : string = '';

  constructor(private http : HttpClient) {

    this.loginUrl = "http://localhost:8080/auth/login";
    this.signUpUrl = "http://localhost:8080/auth/register";

  }

  login_student(student :Student) : Observable<any> {
    console.log(student)
    return this.http.post<any>(this.loginUrl,student);
  }

  login_employer(employer :Employer) : Observable<any> {
    console.log(employer)
    return this.http.post<any>(this.loginUrl,employer);
  }

  signUp(user : User) : Observable<any> {
    console.log(user)
    return this.http.post<any>(this.signUpUrl,user);
  }

  signUp_student(student : Student) : Observable<any> {
    console.log(student)
    return this.http.post<any>(this.signUpUrl,student);
  }

  signUp_employer(employer : Employer) : Observable<any> {
    console.log(employer)
    return this.http.post<any>(this.signUpUrl,employer);
  }
}
