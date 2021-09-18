using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        ICustomerDal _customerDal;
        IFindeksScoreDal _findeksScoreDal;

        public RentalManager(IRentalDal rentalDal , ICarDal carDal , ICustomerDal customerDal , IFindeksScoreDal findeksScoreDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
            _customerDal = customerDal;
            _findeksScoreDal = findeksScoreDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = CheckRentalDate(rental);
            if (result.Success)
            {
                if (CheckFindeksScoreForRental(rental.CarId , rental.CustomerId).Success)
                {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.CarHired);
                }
                else
                {
                    return new ErrorResult(Messages.FindeksScoreIsInsufficient);
                }
               
            }
                return new ErrorResult(result.Message);

        }

        private IResult CheckFindeksScoreForRental(int carId , int customerId)
        {
            Car car = _carDal.Get(c => c.Id == carId);
            Customer customer = _customerDal.Get(cu => cu.Id == customerId);
            FindeksScore findeksScore = _findeksScoreDal.Get(fc => fc.CustomerId == customer.Id);
            if (car.MinFindeksScore <= findeksScore.Score)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckRentalDate(Rental rental)
        {
            var rentals = _rentalDal.GetAll().Where(r => r.ReturnDate.CompareTo(rental.RentDate) > 0).ToList();
            if (rentals.Count!=0)
            {
                return new ErrorResult(Messages.CarNotReturned);
            }
            return new SuccessResult();

        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetLastRentalByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll().Where(r => r.CarId == carId).LastOrDefault());
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll().Where(r => r.CustomerId == customerId).ToList()); ;
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
