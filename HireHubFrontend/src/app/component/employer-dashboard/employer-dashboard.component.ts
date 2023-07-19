import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-employer-dashboard',
  templateUrl: './employer-dashboard.component.html',
  styleUrls: ['./employer-dashboard.component.css']
})
export class EmployerDashboardComponent implements OnInit {

  constructor(private route : Router) { }
  isExpanded: boolean = false;
  
  ngOnInit(): void {
  }
 logout(){
  localStorage.clear();
  this.route.navigate(['/']);
 }
}
