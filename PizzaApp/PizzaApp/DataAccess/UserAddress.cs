using System;
using System.Collections.Generic;

namespace PizzaApp.DataAccess
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ProvidenceState { get; set; }
        public string PostalCode { get; set; }
        public string CountryAbrev { get; set; }

        public virtual UserTbl UserAddressNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
