using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            Products = new HashSet<Product>();
            StoreAddresses = new HashSet<StoreAddress>();
        }

        public int StoreId { get; set; }
        public int? SupplierId { get; set; }
        public string? StoreName { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StoreAddress> StoreAddresses { get; set; }
    }
}
