namespace Condominio.Domain.Models
{
    public class Due
    {
        public int DueId { get;}
        public int CustomerId { get;}
        public decimal Amount { get;}
        public int PaymentDay { get; }
        public decimal PercentCharges { get;}

        //Relations
        public Customer Customer { get;}
        public Due(int dueId, int customerId, decimal amount, int paymentDay, decimal percentCharges)
        {
            DueId = dueId;
            CustomerId = customerId;
            Amount = amount;
            PaymentDay = paymentDay;
            PercentCharges = percentCharges;
        }
    }
}
