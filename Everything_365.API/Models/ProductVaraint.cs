using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class ProductVaraint
    {
        public ProductVaraint()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            Variations = new HashSet<Variation>();
        }

        public int ProductVaraintId { get; set; }
        public int? ProductId { get; set; }
        public int? QtyInStock { get; set; }
        public decimal? Price { get; set; }
        public string? Sku { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public virtual ICollection<Variation> Variations { get; set; }
    }
}
