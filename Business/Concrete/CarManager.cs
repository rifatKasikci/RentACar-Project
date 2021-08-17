using Business.Constants;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concreate;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.ValidationAspects.Autofac;

namespace Business.Concrete
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();

        }

        [SecuredOperation("Cars.List")]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
            }
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice < max && p.DailyPrice > min);
        }
        
        public IDataResult<Car> GetById(int Id)
        {
           return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
             return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id).ToList();
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id).ToList();
        }
       
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
