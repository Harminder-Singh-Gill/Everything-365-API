using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ProductVaraint
    {
        public ProductVaraint()
        {
            ProductConfigrations = new HashSet<ProductConfigration>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ProductVaraintId { get; set; }
        public int? ProductId { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }
        public string? Sku { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<ProductConfigration> ProductConfigrations { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
