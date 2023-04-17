using System;
using System.Collections.Generic;

namespace Everything_365.API.Models
{
    public partial class Variation
    {
        public int VariationId { get; set; }
        public int? ProductVaraintId { get; set; }
        public string? VaraintValue { get; set; }

        public virtual ProductVaraint? ProductVaraint { get; set; }
        public virtual VariationOption? VariationOption { get; set; }
    }
}
