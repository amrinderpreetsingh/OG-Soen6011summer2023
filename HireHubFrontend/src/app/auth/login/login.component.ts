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

  username: string = '';
  password: string = '';
  role: string = '';
  email: string = '';
  student: Student = new Student();
  employer: Employer = new Employer();



  constructor(private authService: AuthService, private route: Router) {
  }

  ngOnInit(): void {
    this.username = '';
    this.password = '';
  }

  login() {
    if (this.email == "admin") {
      this.role = "admin"
    }
    else {
      const email = this.extractDomainFromEmail(this.email);
      
      console.log(email);
      
      if (email == "Gmail"|| email == "Hirehub") {
        this.role = "Student"
      } else {
        this.role = "Employer"
      }
    }
    
    if (this.role == 'Student') {
      this.student.email = this.email;
      this.student.password = this.password;

      this.authService.loginStudent(this.student).subscribe(res => {
        if (res == false) {
          alert("Uername or password is wrong");
          this.ngOnInit();
        } else {
          console.log("Login successful");
          localStorage.setItem("student_email", this.email);

          this.route.navigate(['/Student']);
        }
      }, err => {
        alert("Login failed");
        this.ngOnInit();
      })
    }

    if (this.role == 'Employer') {
      this.employer.companyEmail = this.email;
      this.employer.companyPassword = this.password;

      this.authService.loginEmployer(this.employer).subscribe(res => {
        if (res == false) {
          alert("Uername or password is wrong");
          this.ngOnInit();
        } else {
          console.log("Login successful");
          localStorage.setItem("employer_email", this.email);
          this.route.navigate(['/Employer']);
        }
      }, err => {
        alert("Login failed");
        this.ngOnInit();
      })
    }

    if (this.role == 'admin') {
      this.route.navigate(['/admin-dashboard']);
    }
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

}
