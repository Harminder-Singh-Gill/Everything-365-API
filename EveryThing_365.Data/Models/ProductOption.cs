using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ProductOption
    {
        public ProductOption()
        {
            ProductConfigrations = new HashSet<ProductConfigration>();
        }

        public int ProductOptionId { get; set; }
        public int? ProductId { get; set; }
        public int? VariationId { get; set; }
        public string? OptionValue { get; set; }
        public int? Position { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Variation? Variation { get; set; }
        public virtual ICollection<ProductConfigration> ProductConfigrations { get; set; }
    }
}
