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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, AutomotiveContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (AutomotiveContext context = new AutomotiveContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
