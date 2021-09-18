using Core.Utilities;
using Entities.Concrete;
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
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<Car>> GetByDailyPrice(int min , int max);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<CarDetailDto> GetCarDetailByCarId(int carId);
        IDataResult<List<Car>> GetCarsByFiltered(CarFilter carFilter);
        IDataResult<List<CarDetailDto>> GetCarDetailsByFiltered(CarFilter carFilter);

    }
}
