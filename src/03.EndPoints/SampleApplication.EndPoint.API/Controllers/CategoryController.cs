using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Core.ApplicationService.Categoreis;

namespace SampleApplication.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppService service;

        public CategoryController(CategoryAppService categoryService)
        {
            this.service = categoryService;
        }
        [HttpPost]
        public IActionResult AddCategory(CreateCategoryDto dto)
        {
            service.Add(dto);
            return Ok();
        }
    }
}
