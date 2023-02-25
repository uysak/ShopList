using Business.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        public RefreshToken GenerateRefreshToken();
        public void SetRefreshToken(RefreshToken token, HttpResponse response, User user); //Http Response for access cookie
    }
}
