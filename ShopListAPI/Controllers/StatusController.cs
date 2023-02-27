using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IUserService _userService;

        private readonly IMapper _mapper;


        public StatusController(IStatusService statusService, IMapper mapper,IUserService userService)
        {
            _statusService = statusService;
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("GetAllStatus")]
        public IActionResult GetAllStatus()
        {
            var result = _statusService.GetAll();
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetStatusById([FromRoute] int id)
        {
            var result = _statusService.GetById(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateStatus([FromBody] StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            var result = _statusService.Create(status);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateStatus([FromRoute]int id, [FromBody] StatusDto statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);
            status.Id = id;

            var result = _statusService.Update(status);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStatus([FromRoute] int id)
        {
            var status = _statusService.GetById(id);
            
            if (status == null)
            {
                return NotFound();
            }
            var result = _statusService.Delete(id);
            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }
}
