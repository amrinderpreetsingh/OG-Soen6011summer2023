import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminListEmployerComponent } from './admin-list-employer.component';

describe('AdminListEmployerComponent', () => {
  let component: AdminListEmployerComponent;
  let fixture: ComponentFixture<AdminListEmployerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminListEmployerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminListEmployerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
