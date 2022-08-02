using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }
        public byte BookId { get; set; }
        public string EmailId { get; set; }
        public int OrderId { get; set; }
        public byte Rating { get; set; }
        public string Comments { get; set; }

        public virtual Book Book { get; set; }
        public virtual User Email { get; set; }
        public virtual Order Order { get; set; }
    }
}
