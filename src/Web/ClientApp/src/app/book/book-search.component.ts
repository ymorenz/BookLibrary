import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import {BookDto, BooksClient} from "../web-api-client";

@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.scss']
})
export class BookSearchComponent {
  searchForm = new FormGroup({
    searchBy: new FormControl(''),
    searchValue: new FormControl('')
  });
  books: BookDto[] = [];

  constructor(private bookClient: BooksClient) {}

  onSearch() {
    const searchCriteria = this.searchForm.value.searchValue;
    this.bookClient.getBooksWithPagination(searchCriteria.toString(),1,10).subscribe(
      (results) => {
        this.books = results.items;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
