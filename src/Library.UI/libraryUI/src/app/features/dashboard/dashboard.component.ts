import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import { ApiService } from '../../api.service';
import { HttpClientModule } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [HttpClientModule, MatToolbarModule, MatCardModule, CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss',
  providers: [ApiService]  
})

export class DashboardComponent implements OnInit {
  books: IBook[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {

    this.apiService.getData().subscribe(
      (res: any) => {
        console.log(res);
        this.books = res;
      },
      (error) => {
        console.error('ERROR FETCHING API', error);
      }
    )
  }
}

interface IBook {
  id: number;
  title: string;
  author: string;
  publishedDate: string;
}