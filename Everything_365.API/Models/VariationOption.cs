using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class VariationOption
    {
        public int VariationOptionId { get; set; }
        public int VariationId { get; set; }
        public string? OptionValue { get; set; }

        public virtual Variation Variation { get; set; } = null!;
    }
}
