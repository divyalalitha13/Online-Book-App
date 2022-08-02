using System;
using System.Collections.Generic;

namespace OnlineBookDAL.Models
{
    public partial class Order
    {
        public Order()
        {
            Ratings = new HashSet<Ratings>();
        }

        public int OrderId { get; set; }
        public string EmailId { get; set; }
        public byte BookId { get; set; }
        public int OrderQuantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime EstimatedDelivery { get; set; }

        public virtual Book Book { get; set; }
        public virtual User Email { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}
