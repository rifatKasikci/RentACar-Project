using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concreate
{
    public class InMemory : IInMemoryService
    {
        List<Car> _cars;

        public InMemory()
        {
            _cars = new List<Car> {
            new Car{Id=1,BrandId=1,ColorId=2,DailyPrice=450,Description="Dizel",ModelYear=2018},
            new Car{Id=2,BrandId=3,ColorId=2,DailyPrice=500,Description="Mazotlu",ModelYear=2019},
            new Car{Id=3,BrandId=5,ColorId=2,DailyPrice=650,Description="Benzinli",ModelYear=2020},
            new Car{Id=4,BrandId=4,ColorId=2,DailyPrice=675,Description="Dizel",ModelYear=2017},
            new Car{Id=5,BrandId=2,ColorId=2,DailyPrice=750,Description="Dizel",ModelYear=2021}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete;

            carToDelete = _cars.SingleOrDefault(c => car.Id == c.Id);
          
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
            

        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.BrandId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            
            
        }
    }
}
