import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { BookModel } from 'src/app/models/book.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-bookdetail',
  templateUrl: './bookdetail.component.html',
  styleUrls: ['./bookdetail.component.css']
})
export class BookdetailComponent implements OnInit {

  public id;
  bookModel=new BookModel();
  book:any;

  constructor(public route:Router, private activeRoute:ActivatedRoute ,private service:ApiService ) {
    this.id=this.activeRoute.snapshot.paramMap.get('id');
   }

  ngOnInit(): void {
    this.getId();
  }


  getId(){
    console.log(this.id)
    this.service.getBookById(this.id).subscribe((data)=>{
      console.log(data)
      this.book=data;
      this.bookModel.id=this.book.Id;
      this.bookModel.image=this.book.Image;
      this.bookModel.author=this.book.Author;
      this.bookModel.title=this.book.Title;
      this.bookModel.price=this.book.Price;
      this.url="assets/images/"+this.bookModel.image;
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


  onHome(){
    this.route.navigate(['home'],{replaceUrl:true});
  }

  onSubmit() {
    this.service.editBook(this.id,this.bookModel).subscribe();
    window.location.reload();
  }

}
