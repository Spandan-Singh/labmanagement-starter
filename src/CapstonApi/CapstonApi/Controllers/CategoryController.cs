using CapstoneData.Model;
using CapstoneData.Provider;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneApi.Controllers
{
    [ApiController]
    [Route("Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryProvider _categoryProvider;
        public CategoryController(ILogger<CategoryController> logger, ICategoryProvider categoryProvider)
        {
            _logger = logger;
            _categoryProvider = categoryProvider;
        }

        [HttpGet]
        public IEnumerable<CategoryDbo> GetCategories()
        {
            return _categoryProvider.GetCategories();
        }


        [HttpGet]
        [Route("{id}")]
        public CategoryDbo? RetriveCategoryById(int id)
        {
            return _categoryProvider.GetCategoryById(id);
        }


        [HttpPut]
        [Route("{id}")]
        public CategoryDbo UpdateCategoryById([FromRoute] int id, [FromBody] CategoryDbo category)
        {
            return _categoryProvider.UpdateCategoryById(id, category);
        }


        [HttpPost]
        public CategoryDbo CreateCategory([FromBody] CategoryDbo category)
        {
            return _categoryProvider.CreateCategory(category);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            return Ok(_categoryProvider.DeleteCategoryById(id));
        }
    }
}
