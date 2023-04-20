using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class Variation
    {
        public Variation()
        {
            ProductOptions = new HashSet<ProductOption>();
        }

        public int VariationId { get; set; }
        public string? Value { get; set; }

        public virtual ICollection<ProductOption> ProductOptions { get; set; }
    }
}
