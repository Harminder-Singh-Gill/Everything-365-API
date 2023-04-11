using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Country
    {
        public Country()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            StoreAddresses = new HashSet<StoreAddress>();
        }

        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<StoreAddress> StoreAddresses { get; set; }
    }
}
