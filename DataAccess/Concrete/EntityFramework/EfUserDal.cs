using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, AutomotiveContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (AutomotiveContext context = new AutomotiveContext())
            {
                var result = from u in context.Users
                             join cu in context.Customers
                             on u.Id equals cu.UserId
                             select new UserDetailDto
                             {
                                 CompanyName = cu.CompanyName,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}
