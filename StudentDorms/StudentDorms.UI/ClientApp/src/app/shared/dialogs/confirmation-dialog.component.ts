import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ConfirmationDialogModel } from '../models/shared/confirmation-dialog.model';

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html',
  styles: [
  ]
})
export class ConfirmationDialogComponent implements OnInit {

  model: ConfirmationDialogModel = new ConfirmationDialogModel('', '');

  constructor(public dialogRef: MatDialogRef<ConfirmationDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: any) {
    dialogRef.disableClose = true;
  }

  ngOnInit() {
    this.dialogRef.disableClose = true;
    if (this.data) {
      this.model = this.data.model;
    }
  }

  onCancel() {
    this.dialogRef.close(false);
  }

  onConfirmation() {
    this.dialogRef.close(true);
  }

}
