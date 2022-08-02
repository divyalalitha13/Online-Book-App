import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ILogin } from 'src/app/Interfaces/ILogin';
import { OnlineBookService } from 'src/app/services/online-book.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  status:any;
  errorMsg:string;
  msg:string;
  showMsg:boolean=false;
  login:ILogin;

  constructor(private _onlineBookService:OnlineBookService,private router:Router) { }

  ngOnInit(): void {
  }
  submitLoginForm(form:NgForm){
    this.login={
      emailId:form.value.email,
      userPassword:form.value.password
    }
    this._onlineBookService.validateUserCredentials(this.login).subscribe(
      responseData=>{
        this.status=responseData;
        this.showMsg=true;
        console.log(this.status)
        if(this.status==200){
          sessionStorage.setItem('userName',form.value.email);
          sessionStorage.setItem('isLoggedIn',"true");
          sessionStorage.setItem('Role','User');
          this.msg="Login Successful";
          this.router.navigate(['/home'])
        }
        else{
          this.msg="Invalid Credentials.Try again with valid credentials"
        }
      },
      responseError=>{
        this.showMsg=true;
        this.errorMsg=responseError;
        this.msg="Something went wrong.Please try again"
      },
      ()=>console.log("Validate user credentials executed successfully")
    )
  }
}
