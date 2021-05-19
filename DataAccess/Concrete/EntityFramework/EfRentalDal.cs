using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,ReCapContext> , IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in filter is null ? context.Rentals:context.Rentals.Where(filter)
                             join c in context.Cars on r.Id equals c.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             select new RentalDetailDto { CarId = c.Id, CompanyName = cus.CompanyName, CustomerId = cus.Id, RentId = r.Id, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }

       
    }
}
