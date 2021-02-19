using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        private InMemory ınMemory;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public CarManager(InMemory ınMemory)
        {
            this.ınMemory = ınMemory;
        }

        public void Add(Car car)
        {
            if (car.Description.Length>7 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("Car added.");
            }
            else
            {
                Console.WriteLine("Car couldn't added.");
            }
            
        }

        public List<Car> GetAll()
        {
          return  _carDal.GetAll();
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice < max && p.DailyPrice > min);
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(p => p.Id == Id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id).ToList();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id).ToList();
        }
    }
}
