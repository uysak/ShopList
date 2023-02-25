﻿using Business.Abstract;
using Business.Constants;
using Business.Utilities.Results;
using Business.Utilities.Security;
using Business.Utilities.Security.Hashing;
using Business.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IConfiguration configuration)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _configuration = configuration;
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
                PasswordSalt = passwordSalt,
                PasswordAttemptCount = 0,
                RegistrationDate = DateTime.Now,
                
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var loginedUser = _userService.GetByMail(userForLoginDto.Email).Data;
            if (loginedUser == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var checkPasswordAttemptLimit = CheckPasswordAttemptLimit(loginedUser);

            if (!checkPasswordAttemptLimit.Success)
                return new ErrorDataResult<User>(checkPasswordAttemptLimit.Message);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, loginedUser.PasswordHash, loginedUser.PasswordSalt))
            {
                loginedUser.PasswordAttemptCount += 1;
                _userService.Update(loginedUser);
                return new ErrorDataResult<User>($"{Messages.PasswordError} {checkPasswordAttemptLimit.Message}");
            }

            loginedUser.PasswordAttemptCount = 0;

            return new SuccessDataResult<User>(loginedUser, Messages.SuccessfulLogin);
        }

        public IResult CheckPasswordAttemptLimit(User user)
        {
            var passwordAttemptCount = user.PasswordAttemptCount;
            var maxPasswordAttemptCount = Convert.ToInt16(_configuration["PasswordAttemptOptions:maxAttempt"]);

            var remainingAttemptCount = maxPasswordAttemptCount - passwordAttemptCount;

            if (user.NextLoginAttemptTime > DateTime.Now)
            {
                var remainingMinute = user.NextLoginAttemptTime - DateTime.Now;
                return new ErrorResult(Messages.ExceededAttempt + " " + Messages.RetryAfterMinute + remainingMinute);
            }

            if (remainingAttemptCount != 0)
            {

                return new SuccessResult(Messages.RemainingPassword+remainingAttemptCount);
            }
            else
            {
                var waitMinute =  Convert.ToInt16(_configuration["PasswordAttemptOptions:waitTimeInMinute"]);
                user.NextLoginAttemptTime = DateTime.Now.AddMinutes(waitMinute);
                var remainingMinute = user.NextLoginAttemptTime - DateTime.Now;
                user.PasswordAttemptCount = 0;
                _userService.Update(user);

                return new ErrorResult(Messages.ExceededAttempt + " " + Messages.RetryAfterMinute + remainingMinute);
            }
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
