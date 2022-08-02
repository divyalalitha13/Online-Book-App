import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  img:string;
  role:string;
  commonLayout:boolean=false;
  userLayout:boolean=false;

  constructor() { }

  ngOnInit(): void {
    this.commonLayout=false;
    this.userLayout=false;
    this.img='../assets/OnlineBook.jpeg';
    this.role=sessionStorage.getItem('Role');

    if(this.role=="User"){
      this.userLayout=true;
    }
    else{
      this.commonLayout=true;
    }
  }

}
