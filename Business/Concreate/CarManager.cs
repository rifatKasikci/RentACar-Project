using Business.Abstract;
using DataAccess.Concreate;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        InMemory InMemory;

        public CarManager(InMemory ınMemory)
        {
            InMemory = ınMemory;
        }

        public List<Car> GetAll()
        {
            return InMemory.GetAll(); 
        }

        public List<Car> GetById(int Id)
        {
            return InMemory.GetById(Id);
        }
    }
}
