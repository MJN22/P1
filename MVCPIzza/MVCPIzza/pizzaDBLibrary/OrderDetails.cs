using System;
using System.Collections.Generic;

namespace MVCPIzza
{
    public partial class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza IdNavigation { get; set; }
    }
}
