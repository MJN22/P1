using System;
using System.Collections.Generic;

namespace MVCPIzza
{
    public partial class Store
    {
        public Store()
        {
            StoreIngredients = new HashSet<StoreIngredients>();
        }

        public string StoreAddress { get; set; }
        public int StoreAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ProvidenceState { get; set; }
        public string PostalCode { get; set; }
        public string CountryAbrev { get; set; }

        public virtual ICollection<StoreIngredients> StoreIngredients { get; set; }
    }
}
