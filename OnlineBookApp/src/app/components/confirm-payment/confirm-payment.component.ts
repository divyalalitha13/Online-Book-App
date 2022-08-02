import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ICardDetails } from 'src/app/Interfaces/ICardDetails';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-confirm-payment',
  templateUrl: './confirm-payment.component.html',
  styleUrls: ['./confirm-payment.component.css']
})
export class ConfirmPaymentComponent implements OnInit {
  amount:number;
  status:number;
  errorMsg:number;
  showMsg:boolean;
  emailId:string;
  cardDetails:ICardDetails[];
  choid:string="--Choose card number--";
  constructor(private route:ActivatedRoute,private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
    if(sessionStorage.getItem('userName')==null)
      this.router.navigate(['/userLogin']);
    else
      this.emailId=sessionStorage.getItem('userName')
    this.getCardDetails();
    if(this.cardDetails==null){
      this.showMsg=true;
    }
    this.amount=this.route.snapshot.params['amount'];
    this.getCardDetails();
  }
  getCardDetails(){
    this._onlineBookService.getCardDetails().subscribe(
      responseCard=>{
        this.cardDetails=responseCard;
        if(this.cardDetails.length==0){
          this.showMsg=true;
        }
        else{
          this.showMsg=false;
        }
      },
      responseError=>{
        this.cardDetails=null;
        this.showMsg=true;
        this.errorMsg=responseError;
      },
      ()=>{console.log("Get card details executed successfully");}
    )
  }
  confirmPayment(card:string){
    let Card:ICardDetails[]=this.cardDetails.filter(c=>c.cardNumber==card);
    this._onlineBookService.payment(this.emailId,this.amount,Card[0].cardNumber).subscribe(
      responseConfirm=>{
        this.status=responseConfirm;
        if(this.status<0){
          alert("Payment failed due to insufficient balance.Please try again");
          window.location.reload();
        }
        else{
          alert("Payment success.Booking confirmed.Amount debited:"+this.amount+".Available Balance:"+(Card[0].balance-this.amount));
          this.router.navigate(['/viewOrders']);
        }
      },
      responseError=>{
        alert("Something went wrong.Try again");
        this.router.navigate(['/viewCart'])
      },
      ()=>{console.log("Payment executed successfully");}
    )
  }
}
