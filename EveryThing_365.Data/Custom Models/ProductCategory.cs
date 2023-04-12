using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Custom_Models
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
