using PizzaApp.DataAccess;
using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess
{
    public partial class StoreIngredients
    {
        public int StoreIngredientsAddressId { get; set; }
        public int Id { get; set; }
        public int? IngredientStock { get; set; }
        public int? Quantity { get; set; }

        public virtual Store StoreIngredientsAddress { get; set; }
    }
}
