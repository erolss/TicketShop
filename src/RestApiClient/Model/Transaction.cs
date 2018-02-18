using Newtonsoft.Json;
using System.Text;

namespace TicketShop.RestApiClient.Model
{
    public class Transaction
    {
        /// <summary>
        /// Gets or Sets TransactionID
        /// </summary>
        public int? TransactionID { get; set; }

        /// <summary>
        /// Gets or Sets BuyerLastName
        /// </summary>
        public string BuyerLastName { get; set; }

        /// <summary>
        /// Gets or Sets BuyerFirstName
        /// </summary>
        public string BuyerFirstName { get; set; }

        /// <summary>
        /// Gets or Sets BuyerAddress
        /// </summary>
        public string BuyerAddress { get; set; }

        /// <summary>
        /// Gets or Sets BuyerCity
        /// </summary>
        public string BuyerCity { get; set; }

        /// <summary>
        /// Gets or Sets PaymentStatus
        /// </summary>
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or Sets PaymentReference
        /// </summary>
        public string PaymentReference { get; set; }

        /// <summary>
        /// Gets or Sets BuyerEmail
        /// </summary>
        public string BuyerEmail { get; set; }

        /// <summary>
        /// Gets or Sets BuyerUserId
        /// </summary>
        public string BuyerUserId { get; set; }

        /// <summary>
        /// Gets or Sets TotalAmout
        /// </summary>
        public double? TotalAmount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Transaction {\n");
            sb.Append("  TransactionID: ").Append(TransactionID).Append("\n");
            sb.Append("  BuyerFirstName: ").Append(BuyerFirstName).Append("\n");
            sb.Append("  BuyerLastName: ").Append(BuyerLastName).Append("\n");
            sb.Append("  BuyerAddress: ").Append(BuyerAddress).Append("\n");
            sb.Append("  BuyerCity: ").Append(BuyerCity).Append("\n");
            sb.Append("  BuyerEmail: ").Append(BuyerEmail).Append("\n");
            sb.Append("  BuyerUserId: ").Append(BuyerUserId).Append("\n");
            sb.Append("  PaymentStatus: ").Append(PaymentStatus).Append("\n");
            sb.Append("  PaymentReference: ").Append(PaymentReference).Append("\n");
            sb.Append("  TotalAmount: ").Append(TotalAmount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        
    }
}
