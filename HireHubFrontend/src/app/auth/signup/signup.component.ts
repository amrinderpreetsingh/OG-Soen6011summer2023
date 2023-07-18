import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Employer } from 'src/app/model/employer.model';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  name : string = '';
  username : string = '';
  password : string = '';
  role: string= '';
  school : string= '';
  company : string = '';
  experience : string= '';
  qualification: string= '';
  email: string='';
  location: string= '';
  about: string= '';

 
  employer: Employer= new Employer();
  student: Student = new Student();

  constructor( private authService : AuthService, private route : Router) {
    this.roles = [
      'Student',
      'Employer'
    ]
   }

  ngOnInit(): void {
    this.username = '';
    this.password = '';
    this.name = '';
    this.email='';
    this.about='';
    this.location='';
    this.qualification = '';
    this.experience = '';
  }

  roles : string[];

  signup() {

    if(this.role == "Employer"){
      this.employer.companyName= this.name;
      this.employer.companyPassword= this.password;
      this.employer.companyEmail= this.email;
      this.employer.address= this.location;
      this.employer.about = this.about;

      console.log(this.employer)

      this.authService.signUp_employer(this.employer).subscribe(res => {
        if(res == null) {
          alert("Registration failed");
          this.ngOnInit();
        }else if(res == false){
          alert("Email already exist !");
        }else {
          console.log("Registration successful");
          alert("Registration successful");
          this.route.navigate(['/']);
        }
      }, err => {
        alert("Registration failed.");
        this.ngOnInit();
      })

    }else{
      this.student.name= this.name;
      this.student.password= this.password;
      this.student.school= this.school;
      this.student.email= this.email;
      this.student.qualification= this.qualification;
      this.student.experience = this.experience;

      console.log(this.student)

      this.authService.signUp_student(this.student).subscribe(res => {
        if(res == null) {
          alert("Registration failed");
          this.ngOnInit();
        }
        
        else if(res == false){
          alert("Email already exist !");
        }
        else {
          console.log("Registration successful");
          alert("Registration successful");
          this.route.navigate(['/']);
        }
      }, err => {
        alert("Registration failed.");
        this.ngOnInit();
      })
    }
  }
}
