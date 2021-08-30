using PaymentService.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public bool Pay(int cardNumber, string firstName, string lastName, int cardExpMonth, int cardExpYear, string cvv)
        {
            if (cardExpMonth > DateTime.Now.Month || cardExpYear > DateTime.Now.Year)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
