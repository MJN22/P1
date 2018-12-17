using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess
{
    public partial class Orders
    {
        public int UserOrderAddressId { get; set; }
        public int StoreAddressId { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }

        public virtual OrderDetails IdNavigation { get; set; }
        public virtual Store StoreAddress { get; set; }
        public virtual UserAddress UserOrderAddress { get; set; }
    }
}
