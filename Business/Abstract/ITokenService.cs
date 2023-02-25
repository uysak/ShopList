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

namespace Business.Abstract
{
    public interface ITokenService
    {
        IDataResult<JObject> CreateTokens(User user, HttpResponse response);
        IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user);
        IDataResult<RefreshToken> CreateRefreshToken();
    }
}
