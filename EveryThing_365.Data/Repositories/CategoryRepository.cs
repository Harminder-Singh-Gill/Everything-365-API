using Everything_365.Data.Custom_Models;
using Everything_365.Data.Database_Connection;
using Everything_365.Data.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everything_365.Data.Repositories
{
    public class CategoryRepository : ICategoryInterface
    {
        private SqlCommand? Cmd { get; set; }
        public List<ProductCategoryCustom> GetProductCategories()
        {
            try
            {
                List<ProductCategoryCustom> categories = new List<ProductCategoryCustom>();
                Cmd = new SqlCommand();
                DataSet dataSet = ClsDbConnection.GetDataSet("GetProductCategories", Cmd);
                DataTable dt = dataSet.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    categories = (from DataRow dr in dt.Rows
                                  select new ProductCategoryCustom()
                                  {
                                      CategoryId = Convert.ToInt32(dr["category_id"].ToString() ?? String.Empty),
                                      ParentCategoryId = dr["parent_category_id"].Equals(DBNull.Value) ? null : 
                                                         Convert.ToInt32(dr["parent_category_id"].ToString() ?? String.Empty),
                                      CategoryName = dr["category_name"].Equals(DBNull.Value) ? null : 
                                                     (dr["category_name"].ToString() ?? String.Empty),
                                  }).ToList();
                }
                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
