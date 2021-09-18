using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        ICreditCardDal _creditCardDal;

        public PaymentManager(IPaymentDal paymentDal , ICreditCardDal creditCardDal)
        {
            _paymentDal = paymentDal;
            _creditCardDal = creditCardDal;
        }

        public IResult Pay(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

   

        private bool IsLimitSufficient(CreditCard creditCard , Payment payment)
        {
            if (creditCard.CardLimit < payment.Amount)
            {
                return false;
            }
            return true;
        }
    }
}
