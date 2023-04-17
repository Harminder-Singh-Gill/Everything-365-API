using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int AddressId { get; set; }
        public int? CustomerId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? CountryId { get; set; }
        public bool? IsDefault { get; set; }

        public virtual Country? Country { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
