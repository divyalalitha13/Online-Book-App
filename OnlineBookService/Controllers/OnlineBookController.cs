using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookDAL;
using OnlineBookDAL.Models;

namespace OnlineBookService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OnlineBookController : Controller
    {
        OnlineBookRepository repos;
        public OnlineBookController()
        {
            repos = new OnlineBookRepository();
        }

        #region RegisterUser

        [HttpPost]
        public JsonResult RegisterUser(string firstName, string lastName, string emailId, string userPassword, DateTime dob, string gender, long contactNo, string address)
        {
            int status = -1;
            try
            {
                status = repos.RegisterUser(firstName, lastName, emailId, userPassword, dob, gender, contactNo, address);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }

        #endregion

        #region AddGenre

        [HttpPost]
        public JsonResult AddGenre(string genreName)
        {
            int status = -1;
            try
            {
                status = repos.AddGenre(genreName);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region AddBook

        [HttpPost]
        public JsonResult AddBook(string bookName, string authorName, byte genreId, int maxQuantity, decimal cost, string description)
        {
            int status = -1;
            try
            {
                status = repos.AddBook(bookName, authorName, genreId, maxQuantity, cost, description);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region AddOrder

        [HttpPost]

        public JsonResult AddOrder(string emailId, byte bookId, int orderQuantity, string orderStatus, DateTime orderDate, DateTime estimatedDelivery)
        {
            int status = -1;
            try
            {
                status = repos.AddOrder(emailId, bookId, orderQuantity, orderStatus, orderDate, estimatedDelivery);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region AddOrUpdateWishlist

        [HttpPost]
        public JsonResult AddOrUpdateWishlist(string emailId, byte bookId)
        {
            int status = -1;
            try
            {
                status = repos.AddOrUpdateWishlist(emailId, bookId);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region AddOrUpdateCart

        [HttpPost]
        public JsonResult AddOrUpdateCart(string emailId, byte bookId, int cartQuantity)
        {
            int status = -1;
            try
            {
                status = repos.AddOrUpdateCart(emailId, bookId, cartQuantity);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region AddRatings

        [HttpPost]

        public JsonResult AddRatings(string emailId, byte bookId, int orderId, byte rating, string comments)
        {
            int status = -1;
            try
            {
                status = repos.AddRatings(emailId, bookId, orderId, rating, comments);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region RemoveFromCart

        [HttpDelete]
        public JsonResult RemoveFromCart(string emailId, byte bookId)
        {
            int status = -1;
            try
            {
                status = repos.RemoveFromCart(emailId, bookId);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region RemoveFromWishlist

        [HttpDelete]
        public JsonResult RemoveFromWishlist(string emailId, byte bookId)
        {
            int status = -1;
            try
            {
                status = repos.RemoveFromWishlist(emailId, bookId);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region UpdateOrderStatus

        [HttpPut]
        public JsonResult UpdateOrderStatus(string emailId)
        {
            int status = -1;
            try
            {
                status = repos.UpdateOrderStatus(emailId);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }

        #endregion

        #region UpdateCartQuantity

        [HttpPut]
        public JsonResult UpdateCartQuantity(string emailId, byte bookId, int newQuantity)
        {
            int status = -1;
            try
            {
                status = repos.UpdateCartQuantity(emailId, bookId, newQuantity);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }

        #endregion

        #region ValidateUserCredentials

        [HttpPost]
        public JsonResult ValidateUserCredentials(string emailId, string userPassword)
        {
            int status = -1;
            try
            {
                status = repos.ValidateUserCredentials(emailId, userPassword);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region TotalAmountInCart

        [HttpGet]
        public JsonResult TotalAmountInCart(string emailId)
        {
            decimal cost = -1;
            try
            {
                cost = repos.TotalAmountInCart(emailId);
            }
            catch(Exception ex)
            {
                cost = -1;
            }
            return Json(cost);
        }
        #endregion

        #region GetGenres

        [HttpGet]
        public JsonResult GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                genres = repos.GetGenres();
            }
            catch (Exception ex)
            {
                genres = null;
            }
            return Json(genres);
        }
        #endregion

        #region GetAllBooks

        [HttpGet]
        public JsonResult GetAllBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                books = repos.GetAllBooks();
            }
            catch (Exception ex)
            {
                books = null;
            }
            return Json(books);
        }

        #endregion

        #region GetOrdersByEmail

        [HttpGet]
        public JsonResult GetOrdersByEmail(string emailId)
        {
            List<Order> orders = new List<Order>();
            try
            {
                orders = repos.GetOrdersByEmail(emailId);
            }
            catch(Exception ex)
            {
                orders = null;
            }
            return Json(orders);
        }
        #endregion

        #region GetWishlistByEmail

        [HttpGet]
        public JsonResult GetWishlistByEmail(string emailId)
        {
            List<Wishlist> wishlist = new List<Wishlist>();
            try
            {
                wishlist = repos.GetWishlistByEmail(emailId);
            }
            catch (Exception ex)
            {
                wishlist = null;
            }
            return Json(wishlist);
        }
        #endregion

        #region GetCartByEmail

        [HttpGet]
        public JsonResult GetCartByEmail(string emailId)
        {
            List<Cart> cart = new List<Cart>();
            try
            {
                cart = repos.GetCartByEmail(emailId);
            }
            catch(Exception ex)
            {
                cart = null;
            }
            return Json(cart);
        }
        #endregion

        #region GetRatingsByEmail

        [HttpGet]
        public JsonResult GetRatingsByEmail(string emailId)
        {
            List<Ratings> ratings = new List<Ratings>();
            try
            {
                ratings = repos.GetRatingsByEmail(emailId);
            }
            catch(Exception ex)
            {
                ratings = null;
            }
            return Json(ratings);
        }
        #endregion

        #region GetAllBooksInCartWithMaxQuantityAndCost

        [HttpGet]
        public JsonResult GetAllBooksInCartWithMaxQuantityAndCost(string emailId)
        {
            List<BooksInCart> booksInCarts = new List<BooksInCart>();
            try
            {
                booksInCarts = repos.GetAllBooksInCartWithMaxQuantityAndCost(emailId);
            }
            catch(Exception ex)
            {
                booksInCarts = null;
            }
            return Json(booksInCarts);
        }
        #endregion

        #region GetBooksAndGenre

        [HttpGet]
        public JsonResult GetBooksAndGenre()
        {
            List<BooksAndGenre> booksAndGenres = new List<BooksAndGenre>();
            try
            {
                booksAndGenres = repos.GetBooksAndGenre();
            }
            catch(Exception ex)
            {
                booksAndGenres = null;
            }
            return Json(booksAndGenres);
        }
        #endregion

        #region Payment

        [HttpPut]
        public JsonResult Payment(string emailId, decimal amount, string cardNumber)
        {
            int status = -1;
            try
            {
                status = repos.usp_Payment(emailId, amount, cardNumber);
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return Json(status);
        }
        #endregion

        #region GetBooksInWishlit

        [HttpGet]
        public JsonResult GetBooksInWishlist(string emailId)
        {
            List<BooksAndGenre> books = null;
            try
            {
                books = repos.GetBooksInWishlist(emailId);
            }
            catch(Exception ex)
            {
                books = null;
            }
            return Json(books);
        }
        #endregion

        #region GetBooksInOrders

        [HttpGet]
        public JsonResult GetBooksInOrders(string emailId)
        {
            List<BooksInOrders> books = null;
            try
            {
                books = repos.GetBooksInOrders(emailId);
            }
            catch(Exception ex)
            {
                books = null;
            }
            return Json(books);
        }
        #endregion

        #region GetCardDetails

        [HttpGet]
        public JsonResult GetCardDetails()
        {
            List<CardDetails> card = new List<CardDetails>();
            try
            {
                card = repos.GetCardDetails();
            }
            catch(Exception ex)
            {
                card = null;
            }
            return Json(card);
        }
        #endregion

        #region RatingBookNames

        [HttpGet]
        public JsonResult GetRatingBookNames(string emailId)
        {
            List<RatingsBookNames> books = new List<RatingsBookNames>();
            try
            {
                books = repos.GetRatingsBookNames(emailId);
            }
            catch(Exception ex)
            {
                books = null;
            }
            return Json(books);
        }
        #endregion
    }
}
