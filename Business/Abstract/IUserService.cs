using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {

        //create read update delete getAll 

        IResult Add(User user);

        IDataResult<List<UserDetailDto>> GetAllUserDetail();
        IDataResult<UserDetailDto> GetUserDetailById(int id);

        IResult Update(User user);

        IResult Delete(int id);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);
    }
}
