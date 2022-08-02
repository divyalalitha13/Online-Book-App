import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBooksAndGenre } from 'src/app/Interfaces/IBooksAndGenre';
import { IWishlist } from 'src/app/Interfaces/IWishlist';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-view-wishlist',
  templateUrl: './view-wishlist.component.html',
  styleUrls: ['./view-wishlist.component.css']
})
export class ViewWishlistComponent implements OnInit {
  emailId:string;
  books:IBooksAndGenre[]=[];
  showMsgDiv:boolean;
  bookIds:number[]=[]
  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    this.emailId=sessionStorage.getItem('userName')
    if(sessionStorage.getItem('userName')==null)
    this.router.navigate(['/userLogin']);
  this.viewWishlist(this.emailId);
  if(this.books==null||this.books.length==0){
    this.showMsgDiv=true;
  }
  }
  viewWishlist(emailId:string){
    this._onlineBookService.getBooksInWishlist(emailId).subscribe(
      responseBooksInWishlist=>{
        this.books=responseBooksInWishlist
        if(this.books.length==0)
          this.showMsgDiv=true;
        else
          this.showMsgDiv=false;
      },
      responseVBooksInWishlistError=>{
        this.books=null;
        this.showMsgDiv=true;
      },
      ()=>console.log("Get books in wishlist executed successfully")
    )
  }
  getImage(bookName:string){
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;
    console.log(temp);
  }
  removeFromWishlist(book:IBooksAndGenre){
    let id=Number(book.bookId)
    this._onlineBookService.removeFromWishlist(this.emailId,id).subscribe(
      responseRemoveFromWishlist=>{
        this.ngOnInit();
        alert("Removed from Wishlist successfully!!")
      },
      removeFromWishlistError=>{
        alert("Remove from Wishlist failed")
      },
      ()=>console.log("removed from wishlist successfully")
    )
  }
}
