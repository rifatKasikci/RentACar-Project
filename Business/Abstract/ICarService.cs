using Core.Utilities;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        List<Car> GetByDailyPrice(int min , int max);
        
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);

    }
}
