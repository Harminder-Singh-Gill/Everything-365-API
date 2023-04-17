using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductVaraints = new HashSet<ProductVaraint>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? StoreId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<ProductVaraint> ProductVaraints { get; set; }
    }
}
