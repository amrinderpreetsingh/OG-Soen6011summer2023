import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListApplicantsComponent } from './admin-list-applicants.component';

describe('AdminListApplicantsComponent', () => {
  let component: AdminListApplicantsComponent;
  let fixture: ComponentFixture<AdminListApplicantsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminListApplicantsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminListApplicantsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
