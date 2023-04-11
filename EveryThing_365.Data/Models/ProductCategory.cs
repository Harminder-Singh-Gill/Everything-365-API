using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            InverseParentCategory = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ProductCategory? ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> InverseParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
