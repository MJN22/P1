using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }
        public int? Quantity { get; set; }

        public virtual Pizza IdNavigation { get; set; }
        public virtual Pizza QuantityNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
