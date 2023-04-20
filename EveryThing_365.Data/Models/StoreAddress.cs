using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class StoreAddress
    {
        public int AddressId { get; set; }
        public int? StoreId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public int? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual Store? Store { get; set; }
    }
}
