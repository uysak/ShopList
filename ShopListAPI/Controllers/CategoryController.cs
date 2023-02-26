using AutoMapper;
using Business.Abstract;
using Business.Utilities.Results;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
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
        public IActionResult CreateCategory([FromBody]CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

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
        [HttpPut("{id}")]
        public IActionResult UpdateCategory([FromRoute]int id,[FromBody]CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = id;

            var result = _categoryService.Update(category);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute]int id)
        {
            var result = _categoryService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


    }
}
