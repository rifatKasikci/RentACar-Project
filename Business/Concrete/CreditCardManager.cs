using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {

        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            var creditCardOfCustomer = _creditCardDal.Get(cc=>cc.CustomerId==creditCard.CustomerId && cc.CardNumber.Equals(creditCard.CardNumber));
            if (creditCardOfCustomer is null)
            {
                _creditCardDal.Add(creditCard);
                return new SuccessResult(Messages.CreditCardAdded);
            }
           return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<CreditCard> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(cc=>cc.CustomerId == customerId));
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
