using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class User
    {
        public User()
        {
            Cart = new HashSet<Cart>();
            Order = new HashSet<Order>();
            Ratings = new HashSet<Ratings>();
            Wishlist = new HashSet<Wishlist>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public long ContactNo { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
    }
}
