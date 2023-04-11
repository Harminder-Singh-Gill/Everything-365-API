using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductItems = new HashSet<ProductItem>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual ICollection<ProductItem> ProductItems { get; set; }
    }
}
