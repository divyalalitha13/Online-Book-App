using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Book
    {
        public Book()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
            Ratings = new HashSet<Ratings>();
            Wishlist = new HashSet<Wishlist>();
        }

        public byte BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public byte GenreId { get; set; }
        public int MaxQuantity { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
