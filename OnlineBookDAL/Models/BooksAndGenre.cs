using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookDAL.Models
{
    public class BooksAndGenre
    {
        [Key]
        public byte BookId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public byte GenreId { get; set; }
        public int MaxQuantity { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string GenreName { get; set; }
    }
}
