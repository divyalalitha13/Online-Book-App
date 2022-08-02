using OnlineBookDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OnlineBookDAL
{
    public class OnlineBookRepository
    {
        OnlineBookDBContext context;
        public OnlineBookRepository()
        {
            context = new OnlineBookDBContext();
        }

        #region RegisterUser

        public int RegisterUser(string firstName,string lastName,string emailId,string userPassword,DateTime dob,string gender,long contactNo,string address)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {

                SqlParameter prmFirstName = new SqlParameter("@FirstName", firstName);
                SqlParameter prmLastName = new SqlParameter("@LastName", lastName);
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmUserPassword = new SqlParameter("@UserPassword", userPassword);
                SqlParameter prmDob = new SqlParameter("@DOB", dob);
                SqlParameter prmGender = new SqlParameter("@Gender", gender);
                SqlParameter prmContactNo = new SqlParameter("@ContactNo", contactNo);
                SqlParameter prmAddress = new SqlParameter("@Address", address);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_RegisterUser @FirstName,@LastName,@EmailID,@UserPassword,@DOB,@Gender,@ContactNo,@Address", prmReturnValue, prmFirstName, prmLastName, prmEmailId, prmUserPassword, prmDob, prmGender, prmContactNo, prmAddress);

                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddGenre

        public int AddGenre(string genreName)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmGenreName = new SqlParameter("@GenreName", genreName);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddGenre @GenreName", prmReturnValue, prmGenreName);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddBook

        public int AddBook(string bookName,string authorName,byte genreId,int maxQuantity,decimal cost,string description)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmBookName = new SqlParameter("@BookName", bookName);
                SqlParameter prmAuthorName = new SqlParameter("@AuthorName", authorName);
                SqlParameter prmGenreId = new SqlParameter("@GenreID", genreId);
                SqlParameter prmMaxQuantity = new SqlParameter("@MaxQuantity", maxQuantity);
                SqlParameter prmCost = new SqlParameter("@Cost", cost);
                SqlParameter prmDescription = new SqlParameter("@Description", description);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddBook @BookName,@AuthorName,@GenreID,@MaxQuantity,@Cost,@Description", prmReturnValue, prmBookName, prmAuthorName, prmGenreId, prmMaxQuantity, prmCost, prmDescription);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddOrder

        public int AddOrder(string emailId,byte bookId,int orderQuantity,string orderStatus,DateTime orderDate,DateTime estimatedDelivery)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmOrderQuantity = new SqlParameter("@OrderQuantity", orderQuantity);
                SqlParameter prmOrderStatus = new SqlParameter("@OrderStatus", orderStatus);
                SqlParameter prmOrderDate = new SqlParameter("@OrderDate", orderDate);
                SqlParameter prmEstimatedDelivery = new SqlParameter("@EstimatedDelivery", estimatedDelivery);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddOrder @EmailID,@BookID,@OrderQuantity,@OrderStatus,@OrderDate,@EstimatedDelivery", prmReturnValue, prmEmailId, prmBookId, prmOrderQuantity, prmOrderStatus, prmOrderDate, prmEstimatedDelivery);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddOrUpdateWishlist

        public int AddOrUpdateWishlist(string emailId,byte bookId)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddorUpdateWishlist @EmailID,@BookID", prmReturnValue, prmEmailId, prmBookId);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddOrUpdateCart

        public int AddOrUpdateCart(string emailId, byte bookId,int cartQuantity)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmCartQuantity = new SqlParameter("@CartQuantity", cartQuantity);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddorUpdateCart @EmailID,@BookID,@CartQuantity", prmReturnValue, prmEmailId, prmBookId,prmCartQuantity);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch (Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region AddRatings

        public int AddRatings(string emailId,byte bookId,int orderId,byte rating,string comments)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmOrderId = new SqlParameter("@OrderID", orderId);
                SqlParameter prmRating = new SqlParameter("@Rating", rating);
                SqlParameter prmComments = new SqlParameter("@Comments", comments);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_AddRatings @EmailID,@BookID,@OrderID,@Rating,@Comments", prmReturnValue, prmEmailId, prmBookId, prmOrderId, prmRating, prmComments);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch(Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region RemoveFromCart

        public int RemoveFromCart(string emailId,byte bookId)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_RemoveFromCart @EmailID,@BookID", prmReturnValue, prmEmailId, prmBookId);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch (Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region RemoveFromWishlist

        public int RemoveFromWishlist(string emailId, byte bookId)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_RemoveFromWishlist @EmailID,@BookID", prmReturnValue, prmEmailId, prmBookId);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch (Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region UpdateOrderStatus

        public int UpdateOrderStatus(string emailId)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_UpdateOrderStatus @EmailID", prmReturnValue, prmEmailId);
                if (noOfRows >= 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch (Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region UpdateCartQuantity

        public int UpdateCartQuantity(string emailId,byte bookId,int newQuantity)
        {
            int noOfRows = 0;
            int result = -99;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                SqlParameter prmBookId = new SqlParameter("@BookID", bookId);
                SqlParameter prmNewQuantity = new SqlParameter("@NewQuantity", newQuantity);
                SqlParameter prmReturnValue = new SqlParameter("@ReturnValue", System.Data.SqlDbType.Int);
                prmReturnValue.Direction = System.Data.ParameterDirection.Output;
                noOfRows = context.Database.ExecuteSqlRaw("EXEC @ReturnValue=usp_UpdateCartQuantity @EmailID,@BookID,@NewQuantity", prmReturnValue, prmEmailId, prmBookId,prmNewQuantity);
                if (noOfRows > 0)
                {
                    result = Convert.ToInt32(prmReturnValue.Value);
                }
            }
            catch (Exception ex)
            {
                result = -99;
            }
            return result;
        }
        #endregion

        #region ValidateUserCredentials

        public int ValidateUserCredentials(string emailId,string userPassword)
        {
            int status = -1;
            try
            {
                status = (from u in context.User select OnlineBookDBContext.ValidateUserCredentials(emailId, userPassword)).FirstOrDefault();
            }
            catch(Exception ex)
            {
                status = -1;
            }
            return status;
        }
        #endregion

        #region TotalAmountInCart

        public decimal TotalAmountInCart(string emailId)
        {
            decimal cost = -1;
            try
            {
                cost = (from u in context.User select OnlineBookDBContext.TotalAmountInCart(emailId)).FirstOrDefault();
            }
            catch(Exception ex)
            {
                cost = -1;
            }
            return cost;
        }
        #endregion

        #region GetGenres

        public List<Genre> GetGenres()
        {
            List<Genre> lst = null;
            try
            {
                lst = context.Genre.FromSqlRaw("SELECT * FROM ufn_GetGenres()").ToList();
            }
            catch(Exception ex)
            {
                lst = null;
            }
            return lst;
        }
        #endregion

        #region GetAllBooks

        public List<Book> GetAllBooks()
        {
            List<Book> lst = null;
            try
            {
                lst = context.Book.FromSqlRaw("SELECT * FROM ufn_GetAllBooks()").ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }
        #endregion

        #region GetOrdersByEmail
        public List<Order> GetOrdersByEmail(string emailId)
        {
            List<Order> lst = null;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                lst = context.Order.FromSqlRaw("SELECT * FROM ufn_GetOrdersByEmail(@EmailID)",prmEmailId).ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }

        #endregion

        #region GetWishlistByEmail

        public List<Wishlist> GetWishlistByEmail(string emailId)
        {
            List<Wishlist> lst = null;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                lst = context.Wishlist.FromSqlRaw("SELECT * FROM ufn_GetWishlistByEmail(@EmailID)", prmEmailId).ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }
        #endregion

        #region GetCartByEmail
        public List<Cart> GetCartByEmail(string emailId)
        {
            List<Cart> lst = null;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                lst = context.Cart.FromSqlRaw("SELECT * FROM ufn_GetCartByEmail(@EmailID)", prmEmailId).ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }

        #endregion

        #region GetRatingsByEmail
        public List<Ratings> GetRatingsByEmail(string emailId)
        {
            List<Ratings> lst = null;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                lst = context.Ratings.FromSqlRaw("SELECT * FROM ufn_GetRatingsByEmail(@EmailID)", prmEmailId).ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }


        #endregion

        #region GetAllBooksInCartWithMaxQuantityAndCost

        public List<BooksInCart> GetAllBooksInCartWithMaxQuantityAndCost(string emailId)
        {
            List<BooksInCart> lst = null;
            try
            {
                SqlParameter prmEmailId = new SqlParameter("@EmailID", emailId);
                lst = context.BooksInCart.FromSqlRaw("SELECT * FROM ufn_GetAllBooksInCartWithMaxQuantityAndCost(@EmailID)", prmEmailId).ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }
        #endregion

        #region GetBooksAndGenre

        public List<BooksAndGenre> GetBooksAndGenre()
        {
            List<BooksAndGenre> lst = null;
            try
            {
                lst = context.BooksAndGenre.FromSqlRaw("SELECT * FROM ufn_GetBooksAndGenre()").ToList();
            }
            catch (Exception ex)
            {
                lst = null;
            }
            return lst;
        }
        #endregion

        #region Payment

        //check balance amount is there in card
        //reduce quantity in book
        //add cart books to order and put status as Ordered
        //remove books from cart

        public int usp_Payment(string emailId,decimal amount,string cardNumber)
        {
            int status = -1;
            List<Cart> cart = null;
            try
            {
                var card = context.CardDetails.Find(cardNumber);
                if (card.Balance < amount)
                {
                    status = -1;
                    return status;
                }
                else
                {
                    card.Balance = (int)(Convert.ToDecimal(card.Balance) - amount);
                    status = 1;
                }
                cart=GetCartByEmail(emailId);
                foreach(var c in cart)
                {
                    var book=context.Book.Find(c.BookId);
                    book.MaxQuantity = book.MaxQuantity - c.CartQuantity;
                }
                status = 2;
                foreach(var c in cart)
                {
                    Order order = new Order();
                    order.EmailId = c.EmailId;
                    order.BookId = c.BookId;
                    order.OrderQuantity = c.CartQuantity;
                    order.OrderStatus = "Ordered";
                    order.OrderDate = DateTime.Now;
                    order.EstimatedDelivery = DateTime.Today.AddDays(5);
                    context.Order.Add(order);
                }
                status = 3;
                context.RemoveRange(cart);
                status = 4;
                context.SaveChanges();

            }
            catch(Exception ex)
            {
                status = -1;
            }
            return status;
        }


        #endregion

        #region GetBooksInWishlist

        public List<BooksAndGenre> GetBooksInWishlist(string emailId)
        {
            List<BooksAndGenre> books = null;
            List<Wishlist> wishlist = null;
            List<BooksAndGenre> filteredBooks = new List<BooksAndGenre>();
            BooksAndGenre book = null;
            try
            {
                books = GetBooksAndGenre();
                wishlist = GetWishlistByEmail(emailId);

                foreach(var w in wishlist)
                {
                    book = books.Where(x => x.BookId == w.BookId).FirstOrDefault();
                    if(book != null)
                    {
                        filteredBooks.Add(book);
                    }
                }
            }
            catch(Exception ex)
            {
                filteredBooks = null;
            }
            return filteredBooks;
        }
        #endregion

        #region GetBooksInOrders

        public List<BooksInOrders> GetBooksInOrders(string emailId)
        {
            List<BooksInOrders> books = new List<BooksInOrders>();
            List<BooksAndGenre> booksAndGenre = new List<BooksAndGenre>();
            List<Order> orders = new List<Order>();
            try
            {
                booksAndGenre = GetBooksAndGenre();
                orders = GetOrdersByEmail(emailId);
                var temp = booksAndGenre.Join(orders, b => b.BookId, o => o.BookId, (b, o) => new { b, o }).Select(r => new { r.o.OrderId, r.o.EmailId, r.b.BookId, r.o.OrderQuantity, r.o.OrderStatus, r.o.OrderDate, r.o.EstimatedDelivery, r.b.BookName, r.b.AuthorName, r.b.Cost });
                foreach(var b in temp)
                {
                    BooksInOrders book = new BooksInOrders();
                    book.BookId = b.BookId;
                    book.BookName = b.BookName;
                    book.AuthorName = b.AuthorName;
                    book.Cost = b.Cost;
                    book.OrderId = b.OrderId;
                    book.OrderDate = b.OrderDate;
                    book.OrderStatus = b.OrderStatus;
                    book.OrderQuantity = b.OrderQuantity;
                    book.EstimatedDelivery = b.EstimatedDelivery;
                    book.EmailId = b.EmailId;
                    books.Add(book);
                }
            }
            catch(Exception ex)
            {
                books = null;
                Console.WriteLine(ex);
            }
            return books;
        }
        #endregion

        #region GetCardDetails

        public List<CardDetails> GetCardDetails()
        {
            List<CardDetails> card = new List<CardDetails>();
            try
            {
                card = context.CardDetails.Select(x => x).ToList();
            }
            catch(Exception ex)
            {
                card = null;
            }
            return card;
        }
        #endregion

        #region RatingsBookNames

        public List<RatingsBookNames> GetRatingsBookNames(string emailId)
        {
            List<Ratings> ratings = new List<Ratings>();
            List<BooksAndGenre> books = new List<BooksAndGenre>();
            List<RatingsBookNames> ratingBooks = new List<RatingsBookNames>();
            try
            {
                books = GetBooksAndGenre();
                ratings = GetRatingsByEmail(emailId);
                var temp = books.Join(ratings, b => b.BookId, r => r.BookId, (b, r) => new { b, r });
                foreach(var t in temp)
                {
                    RatingsBookNames rate = new RatingsBookNames();
                    rate.BookId = t.b.BookId;
                    rate.BookName = t.b.BookName;
                    rate.AuthorName = t.b.AuthorName;
                    rate.EmailId = t.r.EmailId;
                    rate.OrderId = t.r.OrderId;
                    rate.Rating = t.r.Rating;
                    rate.Comments = t.r.Comments;
                    rate.RatingId = t.r.RatingId;
                    ratingBooks.Add(rate);
                }

            }
            catch(Exception ex)
            {
                ratingBooks = null;
            }
            return ratingBooks;
        }
        #endregion
    }

}
