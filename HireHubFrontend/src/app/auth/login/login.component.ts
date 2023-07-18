import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employer } from 'src/app/model/employer.model';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username : string = '';
  password : string = '';
  role : string = '';
  email: string = '';

  student : Student= new Student();
  employer : Employer= new Employer();

  roles : string[];

  constructor(private authService : AuthService, private route : Router ) { 
    this.roles = [
      'Student',
      'Employer'
    ]
  }

  ngOnInit(): void {
    this.username = '';
    this.password = '';
  }

  login() {
    if( this.role == 'Student') {
      this.student.email = this.email;
      this.student.password = this.password;

      this.authService.login_student(this.student).subscribe(res => {
        if(res == null) {
          alert("Uername or password is wrong");
          this.ngOnInit();
    }else {
      console.log("Login successful");
      localStorage.setItem("token",res.token);

        this.route.navigate(['/Student']);
    }
  }, err => {
    alert("Login failed");
    this.ngOnInit();
  })}

  if( this.role == 'Employer') {
    this.employer.companyEmail = this.email;
    this.employer.companyPassword = this.password;

    this.authService.login_employer(this.employer).subscribe(res => {
      if(res == null) {
        alert("Uername or password is wrong");
        this.ngOnInit();
  }else {
    console.log("Login successful");
    localStorage.setItem("token",res.token);

      this.route.navigate(['/Employer']);
  }
}, err => {
  alert("Login failed");
  this.ngOnInit();
})}}
}
