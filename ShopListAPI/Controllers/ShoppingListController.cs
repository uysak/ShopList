using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;
using AutoMapper;
using Business.Utilities.Results;
using Microsoft.AspNetCore.Authorization;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListItemService _shoppingListItemService;
        private readonly IShoppingListService _shoppingListService;

        private readonly IMapper _mapper;

        public ShoppingListController(IShoppingListItemService shoppingListItemService, IShoppingListService shoppingListService,IMapper mapper)
        {
            _shoppingListItemService = shoppingListItemService;
            _shoppingListService = shoppingListService;
            _mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("FilterShoppingListByCategory")]
        public IActionResult FilterListByCategoryId(int categoryid)  // Kategori bazlı filtreleme. Verilen categoryId'de ürün içeren alışveriş listelerini getiriyor.
        {
            var result = _shoppingListService.GetAllListItemByCategoryId(categoryid);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet("FilterShoppingListItemByCategoryId")]
        public IActionResult FilterListItemByCategoryId(int categoryId,int listId)
        {
            var result = _shoppingListService.GetAllItemByCategoryId(categoryId,listId);
            return result.Success == true ? Ok(result) : BadRequest(result);

        }

        [Authorize("Admin")]
        [HttpPost("createlist")]
        public IActionResult CreateNewList(ShoppingList shoppingList)
        {
            var result = _shoppingListService.Add(shoppingList);
            return result.Success == true ? Ok(result) : BadRequest(result);

        }
        [Authorize("Admin")]
        [HttpPost("Admin,User")]
        public IActionResult AddItem(ShoppingListItemForAddDto shoppingListItemForAddDto)
        {
            var result = _shoppingListItemService.Add(shoppingListItemForAddDto);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

    }
}
