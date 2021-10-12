import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookModel } from 'src/app/models/book.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  bookModel= new BookModel();

  constructor(public route:Router , public service:ApiService , ) { }

  books:any
  

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks(){
    this.service.getBooks().subscribe((data)=>{
      this.books=data;
      console.log(this.books);
    })
  }





  url = "https://cdn3.vectorstock.com/i/1000x1000/35/52/placeholder-rgb-color-icon-vector-32173552.jpg"
  imagePath:any;
  onSelectFile(e: any) {
    if (e.target.files) {
      //this.url=e.target.files[0].name; 
      //console.log(e.target.value);
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0])
      this.imagePath=e.target.files[0].name
      console.log(e.target.files[0].name);
      this.bookModel.image=e.target.files[0].name;
      //console.log(e.target.files[0]);
      reader.onload = (event: any) => {

        this.url = event.target.result;
        //console.log(this.url);
      }
    }
  }


  onView(id:any){

    this.route.navigate(['view',id])
  }
  
  onDelete(id:any){
    this.service.deleteBook(id).subscribe();
    window.location.reload();
  }


  onSubmit() {
    console.log(this.bookModel);
   this.service.addBook(this.bookModel).subscribe((data)=>{
    console.log(data)
   });
   window.location.reload();
   
    
  }

  // upload($event){

  // }


}
