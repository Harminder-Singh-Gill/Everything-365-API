using Everything_365.Data.DataContext;
using Everything_365.Data.Custom_Models;
using Microsoft.AspNetCore.Mvc;
using Everything_365.Data.Repositories;

namespace Everything_365.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository? categoryRepository;

        [HttpGet]
        public List<ProductCategory> GetProductCategories()
        {
            try
            {
                categoryRepository = new CategoryRepository();
                return categoryRepository.GetProductCategories();
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
