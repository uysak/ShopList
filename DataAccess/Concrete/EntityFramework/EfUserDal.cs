using System;
using System.Collections.Generic;
using System.Linq;

using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ShopListContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new ShopListContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.ClaimId
                             where userOperationClaim.UserId == user.Id

                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name,

                             };
                return result.ToList();
            }
        }

        public List<UserDetailDto> GetAllUserDetail(Expression<Func<User, bool>> filter = null)
        {
            using (var context = new ShopListContext())
            {

                if (filter == null)
                {
                    return context.Users.Include(s => s.Country).Select(u => new UserDetailDto

                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Country = u.Country.CountryName
                    }).ToList();
                }

                else
                {
                    return context.Users.Include(s => s.Country).Where(filter).Select(u => new UserDetailDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        Country = u.Country.CountryName
                    }).ToList();
                }

            }
        }

        public UserDetailDto GetUserDetail(Expression<Func<User, bool>> filter)
        {
            using(var context = new ShopListContext())
            {
                return context.Users.Where(filter).Select(u => new UserDetailDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Country = u.Country.CountryName
                }).FirstOrDefault();
            }
        }
    }
}
