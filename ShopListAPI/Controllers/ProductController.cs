using Business.Abstract;
using Business.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var result = _productService.Create(product);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize]
        [HttpPost("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.Get(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }
}
