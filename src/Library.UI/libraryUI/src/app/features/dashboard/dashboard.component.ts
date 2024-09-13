import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ApiService } from '../../services/api.service';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';
import {MatButtonModule} from '@angular/material/button';
import { IBook } from '../../models/book';

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
    console.log('click');
    const book : IBook = {
      title:"test",
      author: "eu",
      isbn: "string",
      publishedDate: "2024-01-01"
    };

    this.apiService.addBook(book).subscribe(
      (res: any) => {
        console.log('add', res);
      },
      (error) => {
        console.error('ERROR FETCHING API', error);
      }
    );
  }
}
