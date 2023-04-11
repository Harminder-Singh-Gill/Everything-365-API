using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ProductItem
    {
        public ProductItem()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public int ProductItemId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public int? QtyInStock { get; set; }
        public int? Price { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
