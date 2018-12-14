using System;
using System.Collections.Generic;

namespace MVCPIzza
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Costs { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
