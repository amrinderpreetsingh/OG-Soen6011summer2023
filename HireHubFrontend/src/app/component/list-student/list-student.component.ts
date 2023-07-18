import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Student } from 'src/app/model/student.model';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-list-student',
  templateUrl: './list-student.component.html',
  styleUrls: ['./list-student.component.css']
})
export class ListStudentComponent implements OnInit {
  @ViewChild(MatPaginator) paginator !: MatPaginator;
  constructor(private authService : AuthService, private route : Router) { }
  isExpanded: boolean = false;
  ngOnInit(): void {
    this.list_all_students()
  }

  displayedColumns: string[] = ['id', 'name', 'email', 'qualification', 'experience','school'];
  dataSource: any;
  student_data:any = [];
  

  list_all_students(){
     this.authService.get_student_list().subscribe(res=>{
      console.log(res)
      this.student_data= res;
      this.dataSource = new MatTableDataSource<Student>(this.student_data)
      this.dataSource.paginator = this.paginator;
     })
  }

}
