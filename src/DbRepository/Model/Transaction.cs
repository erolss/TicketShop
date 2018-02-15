using System;

namespace TicketApi.Db.Model
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerCity { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentReference { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerUserId { get; set; }
        public double TotalAmount { get; set; }

        public static explicit operator Transaction(global::TicketApi.Models.Transaction v)
        {
            throw new NotImplementedException();
        }
    }
}
