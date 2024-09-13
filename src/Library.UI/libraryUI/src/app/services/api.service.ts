import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IBook } from '../models/book';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'https://localhost:7106/api'; // Swagger API URL
  
  constructor(private http: HttpClient) {}

  // Method to call the .NET API using HttpClient
  getData(): Observable<any> {
    return this.http.get<IBook[]>(`${this.apiUrl}/LibraryBffApi/books`);
  }

  addBook(books: IBook): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/LibraryBffApi/book`, books);
  }

  getBookById(id: number): Observable<any> {
    return this.http.get<IBook>(`${this.apiUrl}/LibraryBffApi/book/${id}`);
  }

  updateBook(book: IBook): Observable<any> {
    return this.http.put<IBook>(`${this.apiUrl}/LibraryBffApi/book/${book.id}`, book);
  }
}
