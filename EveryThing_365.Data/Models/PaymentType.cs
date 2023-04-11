using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            CustomerPayments = new HashSet<CustomerPayment>();
        }

        public int PaymentTypeId { get; set; }
        public string? PaymentValue { get; set; }

        public virtual ICollection<CustomerPayment> CustomerPayments { get; set; }
    }
}
