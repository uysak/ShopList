using Business.Abstract;
using Business.Utilities.Results;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            var result = _categoryService.Create(category);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var result = _categoryService.Get(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var result = _categoryService.Update(category);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


    }
}
