using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookDAL.Models
{
    public class BooksInCart
    {
        [Key]
        public byte BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public byte GenreId { get; set; }
        public int MaxQuantity { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int CartId { get; set; }
        public string EmailId { get; set; }
        public int CartQuantity { get; set; }
    }
}
