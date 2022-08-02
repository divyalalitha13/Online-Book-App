import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { CommonLayoutComponent } from './components/common-layout/common-layout.component';
import { UserLayoutComponent } from './components/user-layout/user-layout.component';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { UserRegisterComponent } from './components/user-register/user-register.component';
import { OnlineBookService } from './services/online-book.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { Routing } from './app.routing';
import { AuthGuardService } from './Guards/auth-guard.service';
import { ViewBooksComponent } from './components/view-books/view-books.component';
import { ViewWishlistComponent } from './components/view-wishlist/view-wishlist.component';
import { ViewCartComponent } from './components/view-cart/view-cart.component';
import { ViewOrdersComponent } from './components/view-orders/view-orders.component';
import { ViewReviewsComponent } from './components/view-reviews/view-reviews.component';
import { CustomerCareComponent } from './components/customer-care/customer-care.component';
import { ConfirmPaymentComponent } from './components/confirm-payment/confirm-payment.component';
import { AddReviewsComponent } from './components/add-reviews/add-reviews.component';
import { RatingDirective } from './directives/rating.directive';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CommonLayoutComponent,
    UserLayoutComponent,
    UserLoginComponent,
    UserRegisterComponent,
    ViewBooksComponent,
    ViewWishlistComponent,
    ViewCartComponent,
    ViewOrdersComponent,
    ViewReviewsComponent,
    CustomerCareComponent,
    ConfirmPaymentComponent,
    AddReviewsComponent,
    RatingDirective
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    Routing
  ],
  providers: [AuthGuardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
