using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
   public class EfCarImageDal:EfEntityRepositoryBase<CarImage,ReCapContext> , ICarImageDal
    {
    }
}
