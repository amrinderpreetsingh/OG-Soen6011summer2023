import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListJobsComponent } from './admin-list-jobs.component';

describe('AdminListJobsComponent', () => {
  let component: AdminListJobsComponent;
  let fixture: ComponentFixture<AdminListJobsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminListJobsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminListJobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
