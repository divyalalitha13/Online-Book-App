import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IBooksInOrders } from 'src/app/Interfaces/IBooksInOrders';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-view-orders',
  templateUrl: './view-orders.component.html',
  styleUrls: ['./view-orders.component.css']
})
export class ViewOrdersComponent implements OnInit {
  emailId:string;
  books:IBooksInOrders[]=[];
  showMsgDiv:boolean;
  amount:number;
  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    this.emailId=sessionStorage.getItem('userName')
    if(sessionStorage.getItem('userName')==null)
    this.router.navigate(['/userLogin']);
  this.viewBooksInOrders(this.emailId);
  if(this.books==null||this.books.length==0){
    this.showMsgDiv=true;
  }
  }
  viewBooksInOrders(emailId:string){
    this._onlineBookService.getBooksInOrders(emailId).subscribe(
      responseBooksInOrders=>{
        this.books=responseBooksInOrders
        if(this.books.length==0)
          this.showMsgDiv=true;
        else
          this.showMsgDiv=false;
      },
      responseBooksInOrdersError=>{
        this.books=null;
        this.showMsgDiv=true;
      },
      ()=>console.log("Get books in orders executed successfully")
    )
  }
  getImage(bookName:string){
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;
    console.log(temp);
  }
  addRating(book:IBooksInOrders){
    this.router.navigate(['/addRating',book.orderId,book.bookId,book.bookName,book.authorName])
  }

}
