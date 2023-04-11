using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class CustomerPayment
    {
        public CustomerPayment()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int PaymentId { get; set; }
        public int? CustomerId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string? PaymentProvider { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? IsDefault { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
