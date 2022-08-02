import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IReviews } from 'src/app/Interfaces/IReviews';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-view-reviews',
  templateUrl: './view-reviews.component.html',
  styleUrls: ['./view-reviews.component.css']
})
export class ViewReviewsComponent implements OnInit {
  reviews:IReviews[];
  showMsg:boolean=false;
  errorMsg:string;
  emailId:string;
  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
  if(sessionStorage.getItem('userName')==null)
    this.router.navigate(['/userLogin']);
  this.emailId=sessionStorage.getItem('userName');
  this.getReviews();
  if(this.reviews=null){
    this.showMsg=true;
  }
  }
  getReviews(){
    this._onlineBookService.getRatings(this.emailId).subscribe(
      responseRatingData=>{
        this.reviews=responseRatingData;
        if(this.reviews.length==0){
          this.showMsg=true;
        }
        else{
          this.showMsg=false;
        }
      },
      responseError=>{
        this.reviews=null;
        this.showMsg=true;
        this.errorMsg=responseError;
      },
      ()=>console.log("get reviews executed successfully")
    )
 
  }
  getImage(bookName:string){
    console.log(temp);
    bookName=bookName.split(' ').join('_')
    var temp:string="assets/".concat(bookName).concat(".jpg");
    return temp;

  }
}
