using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        Car GetById(int Id);

        List<Car> GetByDailyPrice(int min , int max);

        void Add(Car car);

        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

    }
}
