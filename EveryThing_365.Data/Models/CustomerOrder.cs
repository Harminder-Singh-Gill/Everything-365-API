using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class CustomerOrder
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? ProductVaraintId { get; set; }
        public int? Quantity { get; set; }
        public int? PaymentId { get; set; }
        public int? ShippingId { get; set; }
        public int? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? OrderStatusId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual CustomerPayment? Payment { get; set; }
        public virtual ProductVaraint? ProductVaraint { get; set; }
        public virtual CustomerAddress? Shipping { get; set; }
    }
}
