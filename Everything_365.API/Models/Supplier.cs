using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Stores = new HashSet<Store>();
        }

        public int SupplierId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
    }
}
