import { Component, OnInit, ChangeDetectionStrategy, inject } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ApiService } from '../../services/api.service';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import { IBook } from '../../models/book';
import { MatDialog } from '@angular/material/dialog';
import { BookFormDialogComponent } from '../book-form-dialog/book-form-dialog.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HttpClientModule, MatToolbarModule, MatCardModule, CommonModule, MatButtonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  providers: [ApiService]  
})

export class DashboardComponent implements OnInit {
  books: IBook[] = [];
  dialog = inject(MatDialog);
  buttonActionType : 'edit' | 'add' = 'add';

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getData().subscribe(
      (res: IBook[]) => {
        console.log(res);
        this.books = res;
      },
      (error) => {
        console.error('ERROR FETCHING API', error);
      }
    )
  }

  addBook() : void {
    const book : IBook = {
      title:"",
      author: "",
      isbn: "",
      publishedDate: ""
    };
    const dialogRef = this.dialog.open(BookFormDialogComponent, {
      data: {
        book: book,
        buttonActionType: 'add'
      },
    });

    dialogRef.afterClosed().subscribe((result: IBook) => {
      this.apiService.addBook(result).subscribe(
        (res: any) => {
        console.log('add', res);
        },
        (error) => {
          console.error('ERROR FETCHING API', error);
        }
      );
    });
   
  }

  editBook(book: IBook) : void {
    console.log('edit', book);
    const dialogRef = this.dialog.open(BookFormDialogComponent, {
      data: {
        book: book,
        buttonActionType: 'edit'
      },
    });

    dialogRef.afterClosed().subscribe((result: IBook) => {
      this.apiService.updateBook(result).subscribe(
        (res: any) => {
          console.log('add', res);
        },
        (error) => {
          console.error('ERROR FETCHING API', error);
        }
      );
    });

  }
}
