using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Wishlist
    {
        public int WishlistId { get; set; }
        public byte BookId { get; set; }
        public string EmailId { get; set; }

        public virtual Book Book { get; set; }
        public virtual User Email { get; set; }
    }
}
