import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-add-reviews',
  templateUrl: './add-reviews.component.html',
  styleUrls: ['./add-reviews.component.css']
})
export class AddReviewsComponent implements OnInit {
  orderId:number;
  bookId:number;
  bookName:string;
  emailId:string;
  ratings:number;
  comments:string;
  status:number;
  errorMsg:number;
  authorName:string;

  constructor(private route:ActivatedRoute,private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    if(sessionStorage.getItem('userName')==null)
      this.router.navigate(['/userLogin']);
    this.emailId=sessionStorage.getItem('userName');
    this.orderId=this.route.snapshot.params['orderId'];
    this.bookId=this.route.snapshot.params['bookId']
    this.bookName=this.route.snapshot.params['bookName']
    this.authorName=this.route.snapshot.params['authorName']
  }
  rate(rating:string,comment:string){
    var r=Number(rating)
    this._onlineBookService.addRatings(this.emailId,this.bookId,this.orderId,r,comment).subscribe(
      responseRateStatus=>{
      this.status=responseRateStatus;
      if(this.status){
        alert("Review is added for book successfully");
        this.router.navigate(['/viewReviews']);
      }
      else{
        alert("Review book unsuccessful.Please try after some time.");
        this.router.navigate(['/viewOrders']);
      }
    },
    responseRateError=>{
      this.errorMsg=responseRateError;
      console.log(this.errorMsg);
      alert("Some error occured,please try after some time.");
      this.router.navigate(['/viewOrders']);
    },
    ()=>console.log("Review book method executed successfully.")
    );
  }
  getImage(bookName:string){
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;
    console.log(temp);
  }

}
