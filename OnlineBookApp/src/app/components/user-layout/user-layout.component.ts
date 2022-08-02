import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-user-layout',
  templateUrl: './user-layout.component.html',
  styleUrls: ['./user-layout.component.css']
})
export class UserLayoutComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  logOut(){
    sessionStorage.removeItem('userName');
    sessionStorage.removeItem('Role');
    sessionStorage.setItem('isLoggedIn','false');
    this.router.navigate(['/home']);
  }
}
