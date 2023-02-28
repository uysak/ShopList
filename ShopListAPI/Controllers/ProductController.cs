using AutoMapper;
using Business.Abstract;
using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct([FromRoute]int categoryId,[FromBody]ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            
            var result = _productService.Create(product,categoryId);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute]int id)
        {
            var result = _productService.Get(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;

            var result = _productService.Update(product);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute]int id)
        {
            var result = _productService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }
}
