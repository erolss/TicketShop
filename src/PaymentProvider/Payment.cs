namespace TicketSystem.PaymentProvider
{
    public class Payment
    {
        public PaymentStatus PaymentStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public string PaymentReference { get; set; }
        public string OrderReference { get; set; }
    }
}
