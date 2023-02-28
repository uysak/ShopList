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
        private readonly IUserDal _userDal;
        private readonly IStatusService _statusService;

        public UserManager(IUserDal userDal, IStatusService statusService)
        {
            _userDal = userDal;
            _statusService = statusService;
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
            var updatedUser = _userDal.Get(s => s.Id == user.Id);

            user.StatusId = user.StatusId == default ? updatedUser.StatusId : user.StatusId;
            user.Email = user.Email == default ? updatedUser.Email : user.Email;
            user.CountryCode = user.CountryCode == default ? updatedUser.CountryCode : user.CountryCode;
            user.FirstName = user.FirstName == default ? updatedUser.FirstName : user.FirstName;
            user.LastName = user.LastName == default ? updatedUser.LastName : user.LastName;

            _userDal.Update(user);
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(s => s.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(s => s.Id == id);
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

        public IResult ChangeStatus(int userId, int statusId)
        {
            var updatedUser = GetById(userId);
            var status = _statusService.GetById(statusId);

            if (!updatedUser.Success || !status.Success)
            {
                return new ErrorDataResult();
            }

            updatedUser.Data.StatusId = statusId;

            Update(updatedUser.Data);
            return new SuccessResult();

        }
    }
}
