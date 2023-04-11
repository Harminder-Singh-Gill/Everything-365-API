using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int StatusId { get; set; }
        public string? OrderValue { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
