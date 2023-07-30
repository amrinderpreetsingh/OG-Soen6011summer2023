import { Component, OnInit , Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-job-form',
  templateUrl: './edit-job-form.component.html',
  styleUrls: ['./edit-job-form.component.css']
})
export class EditJobFormComponent implements OnInit {
  editForm: FormGroup;

  constructor(private dialogRef: MatDialogRef<EditJobFormComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
      this.editForm = this.formBuilder.group({
        title: [data.title, Validators.required],
        role: [data.role, Validators.required],
        experience: [data.experience, Validators.required],
        type: [data.type, Validators.required],
        skills: [data.skills, Validators.required],
        description: [data.description, Validators.required],
        studentsApplied:[data.studentsApplied],
        postedBy:[data.postedBy],
        id:[data.id, Validators.required]});
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
