import { Injectable } from '@angular/core';
import {HttpClient} from'@angular/common/http';
import { Observable } from 'rxjs';
import { BookModel } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

   endPoint="http://localhost:57436/api/book/";

  constructor(private http:HttpClient ,) { }


  getBooks():Observable<any>{
    return this.http.get<any>(this.endPoint);
  }

  getBookById(id:any):Observable<any>{
    return this.http.get<any>(this.endPoint+id);
  }

  addBook(book:BookModel):Observable<any>{
    return this.http.post<any>(this.endPoint,{
      "Title":book.title,
      "Author":book.author,
      "Price":book.price,
      "Image":book.image
    });
  }


  deleteBook(id:any):Observable<any>{
    return this.http.delete<any>(this.endPoint+id)
  }

  editBook(id:any, book:BookModel):Observable<any>{
    return this.http.put<any>(this.endPoint+id,{
      "Title":book.title,
      "Author":book.author,
      "Price":book.price,
      "Image":book.image
    });
  }


}
