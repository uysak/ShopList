using Entities.Concrete;
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
    }
}
