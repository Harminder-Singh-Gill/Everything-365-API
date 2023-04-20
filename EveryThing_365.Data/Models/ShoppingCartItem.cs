using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ShoppingCartItem
    {
        public int CartItemId { get; set; }
        public int? CartId { get; set; }
        public int? ProductVaraintId { get; set; }
        public int? Quantity { get; set; }

        public virtual ShoppingCart? Cart { get; set; }
        public virtual ProductVaraint? ProductVaraint { get; set; }
    }
}
