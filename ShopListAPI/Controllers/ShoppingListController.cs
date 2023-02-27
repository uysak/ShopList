using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;
using AutoMapper;
using Business.Utilities.Results;

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


        [HttpGet("test")]
        public IActionResult test(int categoryid, int listId)
        {
            var result = _shoppingListService.GetAllListItemByCategoryId(categoryid,listId);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpPost("createlist")]
        public IActionResult CreateNewList(ShoppingList shoppingList)
        {
            var result = _shoppingListService.Add(shoppingList);
            return result.Success == true ? Ok(result) : BadRequest(result);

        }

        [HttpPost("additem")]
        public IActionResult AddItem(ShoppingListItemForAddDto shoppingListItemDto)
        {
            var result = _shoppingListItemService.Add(shoppingListItemDto);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

    }
}
