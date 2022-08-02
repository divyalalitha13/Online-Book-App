import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBooksAndGenre } from 'src/app/Interfaces/IBooksAndGenre';
import { OnlineBookService } from 'src/app/services/online-book.service';
import { IGenre } from 'src/app/Interfaces/IGenre';

@Component({
  selector: 'app-view-books',
  templateUrl: './view-books.component.html',
  styleUrls: ['./view-books.component.css']
})
export class ViewBooksComponent implements OnInit {
  booksAndGenre:IBooksAndGenre[];
  genres:IGenre[];
  filteredbooksAndGenre:IBooksAndGenre[];
  bookAndGenreName:string;
  showMsgDiv1:boolean;
  showMsgDiv2:boolean;
  listGenres:string[];
  searchByGenreName:string="All";
  errMsg1:string;
  errMsg2:string;
  status:number;
  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
  if(sessionStorage.getItem('userName')==null)
    this.router.navigate(['/userLogin']);
  this.getBooksAndGenre();
  this.getGenres();
  if(this.booksAndGenre==null){
    this.showMsgDiv1=true;
  }
  }
  getBooksAndGenre(){
    this._onlineBookService.getBooksAndGenre().subscribe(
      responseBooksAndGenreData=>{
        this.booksAndGenre=responseBooksAndGenreData;
        this.filteredbooksAndGenre=responseBooksAndGenreData;
        this.showMsgDiv1=false;
      },
      responseBooksAndGenreError=>{
        this.booksAndGenre=null;
        this.errMsg1=responseBooksAndGenreError;
      },
      ()=>console.log("Get Books and Genre method executed successfully")
    )
  }
  getGenres(){
    this._onlineBookService.getGenres().subscribe(
      responseGenresData=>{
        this.genres=responseGenresData;
        this.showMsgDiv1=false;
      },
      responseGenresError=>{
        this.genres=null;
        this.errMsg2=responseGenresError;
      },
      ()=>console.log("Get Genre method executed successfully")
    )
  }
  searchBookByGenre(genre:string){
    if(this.bookAndGenreName!=null||this.bookAndGenreName=="")
      this.filteredbooksAndGenre=this.booksAndGenre.filter(bks=>bks.bookName.toLowerCase().indexOf(this.bookAndGenreName.toLowerCase())>=0);
    else
      this.filteredbooksAndGenre=this.booksAndGenre;
    this.searchByGenreName=genre;
    if(genre=="All")
      this.filteredbooksAndGenre=this.filteredbooksAndGenre;
    else
      this.filteredbooksAndGenre=this.filteredbooksAndGenre.filter(bks=>bks.genreName.toString()===genre)
    if(this.filteredbooksAndGenre.length==0)
      this.showMsgDiv1=true;
    else
      this.showMsgDiv1=false;
  }
  searchBookByName(){
    if(this.searchByGenreName=="All")
      this.filteredbooksAndGenre=this.booksAndGenre;
    else
      this.filteredbooksAndGenre=this.booksAndGenre.filter(bks=>bks.genreName.toString()===this.searchByGenreName)
    if(this.bookAndGenreName!=null||this.bookAndGenreName==""){
      this.filteredbooksAndGenre=this.filteredbooksAndGenre.filter(bks=>bks.bookName.toLowerCase().indexOf(this.bookAndGenreName.toLowerCase())>=0);
    }
    else{
      this.filteredbooksAndGenre=this.filteredbooksAndGenre.filter(bks=>bks.genreName.toString()===this.searchByGenreName)
    }
    if(this.filteredbooksAndGenre.length==0)
      this.showMsgDiv2=true;
    else
      this.showMsgDiv2=false;
  }
  getImage(bookName:string){
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;
  }
  disabled(q:number){
    if(q!=0)
      return false
    else
      return true
  }
  addToCart(book:IBooksAndGenre){
    let id:number=Number(book.bookId)
    this._onlineBookService.addToCart(sessionStorage.getItem('userName'),id,1).subscribe(
      responseAddToCart=>{
        this.status=responseAddToCart
        alert("Added to cart successfully!!")
      },
      responseAddToCartError=>{
        this.status=responseAddToCartError
        alert("Add to cart failed.")
      },
      ()=>console.log("add to cart executed successfully")
    )
  }
  addToWishlist(book:IBooksAndGenre){
    let id:number=Number(book.bookId)
    console.log(id)
    console.log(sessionStorage.getItem('userName'))
    this._onlineBookService.addToWishlist(sessionStorage.getItem('userName'),id).subscribe(
      responseAddToWishlist=>{
        this.status=responseAddToWishlist
        console.log(this.status)
        alert("Added to Wishlist successfully!!")
      },
      responseAddToWishlistError=>{
        this.status=responseAddToWishlistError
        alert("Add to wishlist failed,")
      },
      ()=>console.log("add to wishlist executed successfullt")
    )
  }

}
