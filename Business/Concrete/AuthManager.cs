using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
using Business.Utilities.Security;
using Business.Utilities.Security.Hashing;
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
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                CountryCode = userForRegisterDto.CountryCode,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
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
