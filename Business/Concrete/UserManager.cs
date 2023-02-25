using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);

            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(s => s.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserDetailDto>> GetAllUserDetail()
        {
            var result = _userDal.GetAllUserDetail();
            return new SuccessDataResult<List<UserDetailDto>>(result);
        }

        public IDataResult<UserDetailDto> GetUserDetailById(int id)
        {
            var result = _userDal.GetUserDetail(s => s.Id == id);
            return new SuccessDataResult<UserDetailDto>(result);
        }
    }
}
