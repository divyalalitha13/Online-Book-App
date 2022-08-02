using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookDAL.Models
{
    public class RatingsBookNames
    {
        [Key]
        public int RatingId { get; set; }
        public byte BookId { get; set; }
        public string EmailId { get; set; }
        public int OrderId { get; set; }
        public byte Rating { get; set; }
        public string Comments { get; set; }

        public string BookName { get; set; }
        public string AuthorName { get; set; }
    }
}
