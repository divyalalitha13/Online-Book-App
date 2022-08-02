import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBook } from 'src/app/Interfaces/IBook';
import { IBooksAndGenreInCart } from 'src/app/Interfaces/IBooksAndGenreInCart';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-view-cart',
  templateUrl: './view-cart.component.html',
  styleUrls: ['./view-cart.component.css']
})
export class ViewCartComponent implements OnInit {
  emailId:string;
  books:IBooksAndGenreInCart[]=[];
  showMsgDiv:boolean;
  amount:number;
  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    this.emailId=sessionStorage.getItem('userName')
    if(sessionStorage.getItem('userName')==null)
    this.router.navigate(['/userLogin']);
  this.viewCart(this.emailId);
  if(this.books==null||this.books.length==0){
    this.showMsgDiv=true;
  }
  }
  totalAmountInCart(emailId:string){
    this._onlineBookService.totalAmountInCart(emailId).subscribe(
      responseTotalAmountInCart=>{
        this.amount=responseTotalAmountInCart
      },
      responseTotalAmountInCart=>{
        this.amount=0;
      },
      ()=>console.log("Total Amount In cart executed successfully!")
    )
  }
  viewCart(emailId:string){
    this._onlineBookService.getBooksAndGenreInCart(emailId).subscribe(
      responseBooksAndGenreInCart=>{
        this.books=responseBooksAndGenreInCart
        this.totalAmountInCart(emailId)
        if(this.books.length==0)
          this.showMsgDiv=true;
        else
          this.showMsgDiv=false;
      },
      responseBooksAndGenreInCartError=>{
        this.books=null;
        this.showMsgDiv=true;
      },
      ()=>console.log("Get books in cart executed successfully")
    )
  }
  getImage(bookName:string){
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;
    console.log(temp);
  }
  payment(){
    this.router.navigate(['/payment',this.amount])
  }
  updateCartQuantity(q:number,book:IBooksAndGenreInCart){
    let id=Number(book.bookId)
    let qu=Number(q)
    console.log(id)
    console.log(this.emailId)
    console.log(qu)
    this._onlineBookService.updateCartQuantity(this.emailId,id,qu).subscribe(
      responseUpdateCartQuantity=>{
        this.ngOnInit();
        alert("Updated Cart Quantity successfully!!")
      },
      responseUpdateCartQuantityError=>{
        alert("Update Cart Quantity failed")
      },
      ()=>console.log("Update cart quantity executed successfully")
    )
  }
  removeFromCart(book:IBooksAndGenreInCart){
    let id=Number(book.bookId)
    this._onlineBookService.removeFromCart(this.emailId,id).subscribe(
      responseRemoveFromCart=>{
        this.ngOnInit();
        alert("Removed from Cart successfully!!")
      },
      removeFromCartError=>{
        alert("Remove from Cart failed")
      },
      ()=>console.log("removed from cart successfully")
    )
  }
}
