using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Abstract
{
    public interface IPaymentService
    {
        bool Pay(int cardNumber, string firstName, string lastName, int cardExpMonth, int cardExpYear, string cvv);
    }
}
