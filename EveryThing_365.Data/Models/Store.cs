using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            ProductItems = new HashSet<ProductItem>();
            StoreAddresses = new HashSet<StoreAddress>();
        }

        public int StoreId { get; set; }
        public int? SupplierId { get; set; }
        public string? StoreName { get; set; }

        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<ProductItem> ProductItems { get; set; }
        public virtual ICollection<StoreAddress> StoreAddresses { get; set; }
    }
}
