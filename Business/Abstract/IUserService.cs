using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        //create read update delete getAll 

        IResult Add(User user);

        IDataResult<List<UserDetailDto>> GetUserDetails();

        IResult Update(User user);

        IResult Delete(int id);

        IDataResult<List<OperationClaim>> GetClaims(User user);


        IDataResult<User> GetByMail(string email);
    }
}
