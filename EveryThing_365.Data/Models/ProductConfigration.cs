using System;
using System.Collections.Generic;

namespace Everything_365.Data.Models
{
    public partial class ProductConfigration
    {
        public int ProductConfigrationId { get; set; }
        public int? ProductVaraintId { get; set; }
        public int? ProductOptionId { get; set; }

        public virtual ProductOption? ProductOption { get; set; }
        public virtual ProductVaraint? ProductVaraint { get; set; }
    }
}
