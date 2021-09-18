using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IFindeksScoreDal _findeksScoreDal;

        public CustomerManager(ICustomerDal customerDal , IFindeksScoreDal findeksScoreDal)
        {
            _customerDal = customerDal;
            _findeksScoreDal = findeksScoreDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            FindeksScore findeksScore = new FindeksScore() { CustomerId = customer.Id };
            int score = new Random().Next(500, 1900);
            findeksScore.Score = score;
            _findeksScoreDal.Add(findeksScore);
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(u => u.Id == id));
        }

        public IDataResult<CustomerDetailDto> GetCustomerDetailsByUserId(int userId)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetCustomerDetailsByUserId(userId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(CustomerUpdateDto customerUpdateDto)
        {
            var customerForUpdate = GetById(customerUpdateDto.CustomerId).Data;
            customerForUpdate.CompanyName = customerUpdateDto.CompanyName;
            _customerDal.Update(customerForUpdate);
            return new SuccessResult();
        }
    }
}
