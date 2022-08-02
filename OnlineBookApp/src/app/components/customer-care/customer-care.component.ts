import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-care',
  templateUrl: './customer-care.component.html',
  styleUrls: ['./customer-care.component.css']
})
export class CustomerCareComponent implements OnInit {
  img:string;
  constructor(private router:Router) { }

  ngOnInit(): void {
    if(sessionStorage.getItem('userName')==null)
      this.router.navigate(['/userLogin']);
    this.img='../assets/OnlineBook.jpeg';
  }

}
