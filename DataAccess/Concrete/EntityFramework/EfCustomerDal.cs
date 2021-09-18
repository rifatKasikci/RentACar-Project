using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public CustomerDetailDto GetCustomerDetailsByUserId(int userId)
        {
            using (var context = new ReCapContext())
            {
                var result = from customer in context.Customers.Where(c => c.UserId == userId)
                             join findeksScore in context.FindeksScores
                             on customer.FindeksScoreId equals findeksScore.Id
                             select new CustomerDetailDto
                             {
                                 Id = customer.Id,
                                 CompanyName = customer.CompanyName,
                                 FindeksPoint = findeksScore.Score
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
