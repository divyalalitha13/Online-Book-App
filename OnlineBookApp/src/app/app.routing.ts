import { HomeComponent } from "./components/home/home.component";
import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { UserLoginComponent } from "./components/user-login/user-login.component";
import { UserRegisterComponent } from "./components/user-register/user-register.component";
import { ViewBooksComponent } from "./components/view-books/view-books.component";
import { AuthGuardService } from "./Guards/auth-guard.service";
import { ViewWishlistComponent } from "./components/view-wishlist/view-wishlist.component";
import { ViewCartComponent } from "./components/view-cart/view-cart.component";
import { ViewOrdersComponent } from "./components/view-orders/view-orders.component";
import { ViewReviewsComponent } from "./components/view-reviews/view-reviews.component";
import { CustomerCareComponent } from "./components/customer-care/customer-care.component";
import { ConfirmPaymentComponent } from "./components/confirm-payment/confirm-payment.component";
import { AddReviewsComponent } from "./components/add-reviews/add-reviews.component";

const routes: Routes = [
    { path: '', component: HomeComponent },
    { path:'*', component: HomeComponent},
    { path: 'home', component: HomeComponent },
    {path:'userLogin',component:UserLoginComponent},
    {path:'register',component:UserRegisterComponent},
    {path:'viewBooks',component:ViewBooksComponent,canActivate:[AuthGuardService]},
    {path:'viewWishlist',component:ViewWishlistComponent,canActivate:[AuthGuardService]},
    {path:'viewCart',component:ViewCartComponent,canActivate:[AuthGuardService]},
    {path:'viewOrders',component:ViewOrdersComponent,canActivate:[AuthGuardService]},
    {path:'viewReviews',component:ViewReviewsComponent,canActivate:[AuthGuardService]},
    {path:'customerCare',component:CustomerCareComponent,canActivate:[AuthGuardService]},
    {path:'payment/:amount',component:ConfirmPaymentComponent,canActivate:[AuthGuardService]},
    {path:'addRating/:orderId/:bookId/:bookName/:authorName',component:AddReviewsComponent,canActivate:[AuthGuardService]},
    {path: '**', component: HomeComponent }
];

export const Routing: ModuleWithProviders = RouterModule.forRoot(routes);