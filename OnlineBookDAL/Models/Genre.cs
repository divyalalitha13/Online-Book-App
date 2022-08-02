using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        public byte GenreId { get; set; }
        public string GenreName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
