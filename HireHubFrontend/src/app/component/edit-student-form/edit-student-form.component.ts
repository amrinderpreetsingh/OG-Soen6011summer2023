import { Component, OnInit , Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-student-form',
  templateUrl: './edit-student-form.component.html',
  styleUrls: ['./edit-student-form.component.css']
})
export class EditStudentFormComponent implements OnInit {
  editForm: FormGroup;
  constructor(private dialogRef: MatDialogRef<EditStudentFormComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
      this.editForm = this.formBuilder.group({
        id: [data.id, Validators.required],
        name:[data.name, Validators.required],
        school: [data.school, Validators.required],
        experience: [data.experience, Validators.required],
        qualification: [data.qualification, Validators.required],
        email: [data.email, Validators.required],
      password:[data.password, Validators.required]});
    }

  ngOnInit(): void {
  }
  onSave(): void {
    if (this.editForm.valid) {
      this.dialogRef.close(this.editForm.value);
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
  
}
