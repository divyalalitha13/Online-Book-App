using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineBookDAL.Models
{
    public class BooksInOrders
    {
        [Key]
        public int OrderId { get; set; }
        public string EmailId { get; set; }
        public byte BookId { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public decimal Cost { get; set; }
    }
}
