using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public byte BookId { get; set; }
        public string EmailId { get; set; }
        public int CartQuantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual User Email { get; set; }
    }
}
