using System;

namespace Condominio.Domain.Models
{
    public class Payment
    {
        public int PaymentId { get;}
        public int CustomerId { get;}
        public decimal PaymentsAmount { get; }
        public DateTime PaymentDate { get; }

        //Relations
        public Customer Customer { get; }
        public Payment(int paymentId, int customerId, decimal paymentsAmount, DateTime paymentDate)
        {
            PaymentId = paymentId;
            CustomerId = customerId;
            PaymentsAmount = paymentsAmount;
            PaymentDate = paymentDate;
        }

    }
}
