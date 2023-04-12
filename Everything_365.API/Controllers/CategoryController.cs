using Everything_365.Data.DataContext;
using Everything_365.Data.Custom_Models;
using Microsoft.AspNetCore.Mvc;
using Everything_365.Data.Repositories;
using Everything_365.Data.Interfaces;

namespace Everything_365.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryInterface? categoryInterface;

        [HttpGet]
        public List<ProductCategory> GetProductCategories()
        {
            try
            {
                categoryInterface = new CategoryRepository();
                return categoryInterface.GetProductCategories();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
