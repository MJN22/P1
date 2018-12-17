using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderDetailsIdNavigation = new HashSet<OrderDetails>();
            OrderDetailsQuantityNavigation = new HashSet<OrderDetails>();
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }
        public string PizzaName { get; set; }
        public decimal Costs { get; set; }

        public virtual ICollection<OrderDetails> OrderDetailsIdNavigation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetailsQuantityNavigation { get; set; }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
