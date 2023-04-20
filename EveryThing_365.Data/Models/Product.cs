using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductOptions = new HashSet<ProductOption>();
            ProductVaraints = new HashSet<ProductVaraint>();
        }

        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? StoreId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ProductCategory? Category { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; }
        public virtual ICollection<ProductVaraint> ProductVaraints { get; set; }
    }
}
