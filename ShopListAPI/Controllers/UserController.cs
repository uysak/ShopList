using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper, IStatusService statusService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult GetAllUserDetail()
        {
            var result = _userService.GetAllUserDetail();
            return result.Success == true ? Ok(result) : BadRequest(result);

        }

        [Authorize(Roles ="Admin")]
        [HttpGet("{id}")]
        public IActionResult GetUserDetailById([FromRoute]int id)
        {
            var result = _userService.GetUserDetailById(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromRoute] int id,[FromBody]UserDetailDto userDetailDto)
        {
            var user = _mapper.Map<User>(userDetailDto);
            user.Id = id;

            var result = _userService.Update(user);
            return result.Success == true ? Ok(result) : BadRequest(result);

        }

        [Authorize(Roles ="Admin")]
        [HttpDelete]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var result = _userService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult ChangeStatus([FromRoute] int userId, [FromRoute] int statusId)
        {
            var result = _userService.ChangeStatus(userId, statusId);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }
}
