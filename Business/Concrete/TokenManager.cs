using Business.Abstract;
using Business.Utilities.Results;
using Business.Utilities.Security.JWT;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public TokenManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IDataResult<RefreshToken> CreateRefreshToken()
        {
            var refreshToken = _tokenHelper.GenerateRefreshToken();
            return new SuccessDataResult<RefreshToken>(refreshToken);
        }
        public IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user)
        {
            _tokenHelper.SetRefreshToken(refreshToken, response, user);
            return new SuccessResult();
        }

        public IDataResult<JObject> CreateTokens(User user, HttpResponse response)
        {
            var accessToken = CreateAccessToken(user).Data;
            var refreshToken = _tokenHelper.GenerateRefreshToken();

            _tokenHelper.SetRefreshToken(refreshToken, response, user); // refresh tokken adding cookie

            JObject tokens = new JObject(
                new JProperty("AccessToken", accessToken.Token),
                new JProperty("RefreshToken", refreshToken.Token)
                );

            _userService.Update(user);

            return new SuccessDataResult<JObject>(tokens);

        }
    }
}
