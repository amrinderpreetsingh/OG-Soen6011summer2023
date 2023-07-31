import { Component, OnInit , Inject} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-employer-form',
  templateUrl: './edit-employer-form.component.html',
  styleUrls: ['./edit-employer-form.component.css']
})
export class EditEmployerFormComponent implements OnInit {
  editForm: FormGroup;

  constructor(private dialogRef: MatDialogRef<EditEmployerFormComponent>,
    private formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
      this.editForm = this.formBuilder.group({
        companyName: [data.companyName, Validators.required],
        companyEmail: [data.companyEmail, Validators.required],
        companyPassword: [data.companyPassword, Validators.required],
        about: [data.about, Validators.required],
        address: [data.address, Validators.required],
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
