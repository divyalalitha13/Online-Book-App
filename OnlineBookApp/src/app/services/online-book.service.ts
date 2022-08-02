import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError, of} from 'rxjs';
import { catchError, mapTo, tap} from 'rxjs/operators';
import { IUser } from '../Interfaces/IUser';
import { ILogin } from '../Interfaces/ILogin';
import { IBook } from '../Interfaces/IBook';
import { IBooksAndGenre } from '../Interfaces/IBooksAndGenre';
import { IGenre } from '../Interfaces/IGenre';
import { IWishlist } from '../Interfaces/IWishlist';
import { IBooksAndGenreInCart } from '../Interfaces/IBooksAndGenreInCart';
import { IBooksInOrders } from '../Interfaces/IBooksInOrders';
import { ICardDetails } from '../Interfaces/ICardDetails';
import { IReviews } from '../Interfaces/IReviews';

@Injectable({
  providedIn: 'root'
})
export class OnlineBookService {

  url :string;
  private loggedUser:string;
  constructor(private http:HttpClient) { }

  addUserDetails(userObj:IUser):Observable<number>{
    let url:string="?firstName="+userObj.firstName+"&lastName="+userObj.lastName+"&emailId="+userObj.emailId+"&userPassword="+userObj.userPassword+"&dob="+userObj.dob+"&gender="+userObj.gender+"&contactNo="+userObj.contactNo+"&address="+userObj.address;
    let temp=this.http.post<number>('https://localhost:44368/api/OnlineBook/RegisterUser'+url,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  validateUserCredentials(loginObj:ILogin):Observable<number>{
    let url:string="?emailId="+loginObj.emailId+"&userPassword="+loginObj.userPassword;
    let temp=this.http.post<number>('https://localhost:44368/api/OnlineBook/ValidateUserCredentials'+url,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  getBooksAndGenre():Observable<IBooksAndGenre[]>{
    let temp=this.http.get<IBooksAndGenre[]>('https://localhost:44368/api/OnlineBook/GetBooksAndGenre').pipe(catchError(this._errorHandler))
    return temp;
  }
  getBooks():Observable<IBook[]>{
    let temp=this.http.get<IBook[]>('https://localhost:44368/api/OnlineBook/GetAllBooks').pipe(catchError(this._errorHandler))
    return temp;
  }
  getGenres():Observable<IGenre[]>{
    let temp=this.http.get<IGenre[]>('https://localhost:44368/api/OnlineBook/GetGenres').pipe(catchError(this._errorHandler))
    return temp;
  }
  addToCart(emaildId:string,bookId:number,quantity:number):Observable<number>{
    let temp=this.http.post<number>('https://localhost:44368/api/OnlineBook/AddOrUpdateCart?emailId='+emaildId+'&bookId='+bookId+'&cartQuantity='+quantity,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  addToWishlist(emaildId:string,bookId:number):Observable<number>{
    let temp=this.http.post<number>('https://localhost:44368/api/OnlineBook/AddOrUpdateWishlist?emailId='+emaildId+'&bookId='+bookId,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  viewWishlist(emailId:string):Observable<IWishlist[]>{
    let temp=this.http.get<IWishlist[]>('https://localhost:44368/api/OnlineBook/GetWishlistByEmail?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  removeFromWishlist(emailId:string,bookId:number):Observable<number>{
    let temp=this.http.delete<number>('https://localhost:44368/api/OnlineBook/RemoveFromWishlist?emailId='+emailId+'&bookId='+bookId).pipe(catchError(this._errorHandler))
    return temp;
  }
  removeFromCart(emailId:string,bookId:number):Observable<number>{
    let temp=this.http.delete<number>('https://localhost:44368/api/OnlineBook/RemoveFromCart?emailId='+emailId+'&bookId='+bookId).pipe(catchError(this._errorHandler))
    return temp;
  }
  getBooksInWishlist(emailId:string):Observable<IBooksAndGenre[]>{
    let temp=this.http.get<IBooksAndGenre[]>('https://localhost:44368/api/OnlineBook/GetBooksInWishlist?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  getBooksAndGenreInCart(emailId:string):Observable<IBooksAndGenreInCart[]>{
    let temp=this.http.get<IBooksAndGenreInCart[]>('https://localhost:44368/api/OnlineBook/GetAllBooksInCartWithMaxQuantityAndCost?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  updateCartQuantity(emailId:string,bookId:number,newQuantity:number):Observable<number>{
    let temp=this.http.put<number>('https://localhost:44368/api/OnlineBook/UpdateCartQuantity?emailId='+emailId+'&bookId='+bookId+'&newQuantity='+newQuantity,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  totalAmountInCart(emailId:string):Observable<number>{
    let temp=this.http.get<number>('https://localhost:44368/api/OnlineBook/TotalAmountInCart?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  getBooksInOrders(emailId:string):Observable<IBooksInOrders[]>{
    let temp=this.http.get<IBooksInOrders[]>('https://localhost:44368/api/OnlineBook/GetBooksInOrders?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  getCardDetails():Observable<ICardDetails[]>{
    let temp=this.http.get<ICardDetails[]>('https://localhost:44368/api/OnlineBook/GetCardDetails').pipe(catchError(this._errorHandler))
    return temp;
  }
  payment(emailId:string,amount:number,cardNumber:string):Observable<number>{
    let temp=this.http.put<number>('https://localhost:44368/api/OnlineBook/Payment?emailId='+emailId+'&amount='+amount+'&cardNumber='+cardNumber,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  addRatings(emailId:string,bookId:number,orderId:number,rating:number,comments:string):Observable<number>{
    let temp=this.http.post<number>('https://localhost:44368/api/OnlineBook/AddRatings?emailId='+emailId+'&bookId='+bookId+'&orderId='+orderId+'&rating='+rating+'&comments='+comments,null).pipe(catchError(this._errorHandler))
    return temp;
  }
  getRatings(emailId:string):Observable<IReviews[]>{
    let temp=this.http.get<IReviews[]>('https://localhost:44368/api/OnlineBook/GetRatingBookNames?emailId='+emailId).pipe(catchError(this._errorHandler))
    return temp;
  }
  _errorHandler(error:HttpErrorResponse){
    console.log(error);
    return throwError(error.message||'Server error')
  }

}
