import {Component, inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogTitle,
  MatDialogContent,
  MatDialogModule,
  MatDialogActions,
  MatDialogClose,
  MatDialogRef,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { IBook } from '../../models/book';

export interface DialogData {
  book: IBook;
  buttonActionType: 'edit' | 'add';
}

@Component({
  selector: 'app-book-form-dialog',
  standalone: true,
  imports: [MatDialogTitle, MatDialogContent, MatButtonModule, MatDialogModule,
    FormsModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule, MatDialogActions, MatDialogClose],
  templateUrl: './book-form-dialog.component.html',
  styleUrl: './book-form-dialog.component.scss'
})

export class BookFormDialogComponent {
  dialogRef = inject(MatDialogRef<BookFormDialogComponent>);
  data = inject<DialogData>(MAT_DIALOG_DATA);

  buttonActionType = this.data.buttonActionType;
  book = this.data.book;

  onSubmit(): void {
    console.log(this.book);
  }
}
