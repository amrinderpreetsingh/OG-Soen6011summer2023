import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListStudentComponent } from './admin-list-student.component';

describe('AdminListStudentComponent', () => {
  let component: AdminListStudentComponent;
  let fixture: ComponentFixture<AdminListStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminListStudentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminListStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
