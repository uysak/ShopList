using Business.Utilities.Results;
using Business.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<JObject> CreateTokens(User user, HttpResponse response);
        IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user);
        IDataResult<RefreshToken> CreateRefreshToken();
    }
}
