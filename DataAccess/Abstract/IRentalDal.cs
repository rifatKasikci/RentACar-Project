using Core.DataAccess;
using Core.Utilities;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
       List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental,bool>> filter = null);
    }
}
