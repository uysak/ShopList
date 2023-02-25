using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ShopListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;


        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var loggedUser = _authService.Login(userForLoginDto);
            if (!loggedUser.Success)
            {
                return BadRequest(loggedUser.Message);
            }

            var result = _authService.CreateTokens(loggedUser.Data, Response);

            //var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Content(result.Data.ToString(), "application/json");
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registeredUser = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var result = _authService.CreateTokens(registeredUser.Data, Response);
            if (result.Success)
            {
                return Content(result.Data.ToString(), "application/json");
            }

            return BadRequest(result.Message);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(string? refreshToken, string usermail)
        {
            var user = _userService.GetByMail(usermail);
            var _refreshToken = string.Empty;

            if (!user.Success)
                return BadRequest(Messages.UserNotFound);


            _refreshToken = refreshToken == null ? Request.Cookies["RefreshToken"] : refreshToken;


            if (!user.Data.RefreshToken.Equals(_refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.Data.TokenExpire < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            var result = _authService.CreateTokens(user.Data, Response);  // it contains refresh token and access token 

            if (result.Success)
            {
                return Content(result.Data.ToString(), "application/json");
            }
            return BadRequest(result.Message);

        }


    }
}
