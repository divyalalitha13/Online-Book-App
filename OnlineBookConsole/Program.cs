using OnlineBookDAL;
using System;

namespace OnlineBookConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineBookRepository repos = new OnlineBookRepository();

            #region RegisterUser

            //var dob = new DateTime(1999, 06, 22);
            //var result1 = repos.RegisterUser("pavan", "medharamettla", "pavan@gmail.com", "pavan@22",dob, "M", 8374329944, "chittoor");
            //Console.WriteLine(result1);
            #endregion

            #region AddGenre

            //var result2 = repos.AddGenre("Auto-Biography");
            //Console.WriteLine(result2);

            #endregion

            #region AddBook

            //decimal to double convert
            //var result3 = repos.AddBook("Harry Potter", "J.K.Rowling", 3, 4, 300, "enter into hogwarts and witness the magic");
            //Console.WriteLine(result3);
            #endregion

            #region AddOrder

            //var result4 = repos.AddOrder("pavan@gmail.com", 5, 2, "Ordered", DateTime.Now, new DateTime(2022, 07, 31));
            //Console.WriteLine(result4);
            #endregion

            #region AddOrUpdateWishlist

            //var result5 = repos.AddOrUpdateWishlist("pavan@gmail.com", 3);
            //Console.WriteLine(result5);
            #endregion

            #region AddOrUpdateCart

            //var result6 = repos.AddOrUpdateCart("pavan@gmail.com", 3,2);
            //Console.WriteLine(result6);
            #endregion

            #region AddRatings

            //var result7 = repos.AddRatings("pavan@gmail.com", 3, 1001, 4, "nice");
            //Console.WriteLine(result7);
            #endregion

            #region RemoveFromCart

            //var result8 = repos.RemoveFromCart("pavan@gmail.com", 3);
            //Console.WriteLine(result8);
            #endregion

            #region RemoveFromWishlist

            //var result9 = repos.RemoveFromWishlist("pavan@gmail.com", 3);
            //Console.WriteLine(result9);
            #endregion

            #region UpdateOrderStatus

            //var result10 = repos.UpdateOrderStatus("pavan@gmail.com");
            //Console.WriteLine(result10);
            #endregion

            #region UpdateCartQuantity

            //var result11 = repos.UpdateCartQuantity("lingamdivya13@gmail.com", 3, 2);
            //Console.WriteLine(result11);
            #endregion

            #region ValidateUserCredentials

            //var result12 = repos.ValidateUserCredentials("pavan@gmail.com", "pavan@22");
            //Console.WriteLine(result12);
            #endregion

            #region TotalAmountInCart

            //var result13 = repos.TotalAmountInCart("lingamdivya13@gmail.com");
            //Console.WriteLine(result13);
            #endregion

            #region GetGenres
            //var lst1 = repos.GetGenres();
            //foreach (var l in lst1)
            //{
            //    Console.WriteLine(l.GenreId);
            //    Console.WriteLine(l.GenreName);
            //}
            #endregion

            #region GetAllBooks

            //var lst2 = repos.GetAllBooks();
            //foreach (var l in lst2)
            //{
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.GenreId);
            //    Console.WriteLine(l.Cost);
            //    Console.WriteLine(l.Description);

            //}
            #endregion

            #region GetOrdersByEmail

            //var lst3 = repos.GetOrdersByEmail("lingamdivya13@gmail.com");
            //foreach (var l in lst3)
            //{
            //    Console.WriteLine(l.OrderId);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.OrderQuantity);
            //    Console.WriteLine(l.OrderStatus);
            //    Console.WriteLine(l.OrderDate);
            //    Console.WriteLine(l.EstimatedDelivery);

            //}

            #endregion

            #region GetWishlistByEmail

            //var lst4 = repos.GetWishlistByEmail("lingamdivya13@gmail.com");
            //foreach (var l in lst4)
            //{
            //    Console.WriteLine(l.WishlistId);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.BookId);

            //}
            #endregion

            #region GetCartByEmail

            //var lst5 = repos.GetCartByEmail("lingamdivya13@gmail.com");
            //foreach (var l in lst5)
            //{
            //    Console.WriteLine(l.CartId);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.CartQuantity);

            //}
            #endregion

            #region GetRatingsByEmail

            //var lst6 = repos.GetRatingsByEmail("lingamdivya13@gmail.com");
            //foreach (var l in lst6)
            //{
            //    Console.WriteLine(l.RatingId);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.OrderId);
            //    Console.WriteLine(l.Rating);
            //    Console.WriteLine(l.Comments);

            //}
            #endregion

            #region GetAllBooksInCartWithMaxQuantityAndCost

            //var lst7 = repos.GetAllBooksInCartWithMaxQuantityAndCost("lingamdivya13@gmail.com");
            //foreach (var l in lst7)
            //{
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.MaxQuantity);
            //    Console.WriteLine(l.GenreId);
            //    Console.WriteLine(l.Cost);
            //    Console.WriteLine(l.Description);
            //    Console.WriteLine(l.CartId);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.CartQuantity);

            //}
            #endregion

            #region GetBooksAndGenre

            //var lst8 = repos.GetBooksAndGenre();
            //foreach (var l in lst8)
            //{
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.MaxQuantity);
            //    Console.WriteLine(l.GenreId);
            //    Console.WriteLine(l.Cost);
            //    Console.WriteLine(l.Description);
            //    Console.WriteLine(l.GenreName);

            //}
            #endregion

            #region Payment

            //var status = repos.usp_Payment("lingamdivya13@gmail.com", 998, "3456234512578970");
            //Console.WriteLine(status);
            #endregion

            #region GetBooksInWishlist

            //var lst = repos.GetBooksInWishlist("pavan@gmail.com");
            //foreach(var l in lst)
            //{
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.GenreId);
            //    Console.WriteLine(l.GenreName);
            //    Console.WriteLine(l.MaxQuantity);
            //    Console.WriteLine(l.Cost);
            //    Console.WriteLine(l.Description);
            //}
            #endregion

            #region GetBooksInOrders

            //var lst = repos.GetBooksInOrders("pavan@gmail.com");
            //foreach(var l in lst)
            //{
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.Cost);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.EstimatedDelivery);
            //    Console.WriteLine(l.OrderDate);
            //    Console.WriteLine(l.OrderId);
            //    Console.WriteLine(l.OrderQuantity);
            //    Console.WriteLine(l.OrderStatus);
            //}
            #endregion

            #region GetCardDetails

            //var lst = repos.GetCardDetails();
            //foreach(var l in lst)
            //{
            //    Console.WriteLine(l.Balance);
            //    Console.WriteLine(l.CardNumber);
            //}
            #endregion

            #region RatingsBookNames

            //var lst = repos.GetRatingsBookNames("pavan@gmail.com");
            //foreach(var l in lst)
            //{
            //    Console.WriteLine(l.AuthorName);
            //    Console.WriteLine(l.BookId);
            //    Console.WriteLine(l.BookName);
            //    Console.WriteLine(l.Comments);
            //    Console.WriteLine(l.EmailId);
            //    Console.WriteLine(l.OrderId);
            //    Console.WriteLine(l.Rating);
            //    Console.WriteLine(l.RatingId);
            //}
            #endregion
        }

    }
}
