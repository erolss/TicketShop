using System;
using System.Text;
using System.Runtime.Serialization;

namespace TicketApi.Db.Models
{
    [DataContract]
    public partial class Transaction : IEquatable<Transaction>
    {
        /// <summary>
        /// Gets or Sets TransactionID
        /// </summary>
        [DataMember(Name = "transactionId")]
        public int? TransactionID { get; set; }

        /// <summary>
        /// Gets or Sets BuyerLastName
        /// </summary>
        [DataMember(Name = "buyerLastName")]
        public string BuyerLastName { get; set; }

        /// <summary>
        /// Gets or Sets BuyerFirstName
        /// </summary>
        [DataMember(Name = "buyerFirstName")]
        public string BuyerFirstName { get; set; }

        /// <summary>
        /// Gets or Sets BuyerAddress
        /// </summary>
        [DataMember(Name = "buyerAddress")]
        public string BuyerAddress { get; set; }

        /// <summary>
        /// Gets or Sets BuyerCity
        /// </summary>
        [DataMember(Name = "buyerCity")]
        public string BuyerCity { get; set; }

        /// <summary>
        /// Gets or Sets PaymentStatus
        /// </summary>
        [DataMember(Name = "paymentStatus")]
        public string PaymentStatus { get; set; }

        /// <summary>
        /// Gets or Sets PaymentReference
        /// </summary>
        [DataMember(Name = "paymentReference")]
        public string PaymentReference { get; set; }

        /// <summary>
        /// Gets or Sets BuyerEmail
        /// </summary>
        [DataMember(Name = "buyerEmail")]
        public string BuyerEmail { get; set; }

        /// <summary>
        /// Gets or Sets BuyerUserId
        /// </summary>
        [DataMember(Name = "buyerUserId")]
        public string BuyerUserId { get; set; }

        /// <summary>
        /// Gets or Sets TotalAmout
        /// </summary>
        [DataMember(Name = "totalAmount")]
        public double? TotalAmount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Transaction {\n");
            sb.Append("  Id: ").Append(TransactionID).Append("\n");
            sb.Append("  FirstName: ").Append(BuyerFirstName).Append("\n");
            sb.Append("  LastName: ").Append(BuyerLastName).Append("\n");
            sb.Append("  Address: ").Append(BuyerAddress).Append("\n");
            sb.Append("  City: ").Append(BuyerCity).Append("\n");
            sb.Append("  Email: ").Append(BuyerEmail).Append("\n");
            sb.Append("  UserId: ").Append(BuyerUserId).Append("\n");
            sb.Append("  PaymentStatus: ").Append(PaymentStatus).Append("\n");
            sb.Append("  PaymentReferenceId: ").Append(PaymentReference).Append("\n");
            sb.Append("  PaymentReferenceId: ").Append(TotalAmount).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        ///// <summary>
        ///// Returns the JSON string presentation of the object
        ///// </summary>
        ///// <returns>JSON string presentation of the object</returns>
        //public string ToJson()
        //{
        //    return JsonConvert.SerializeObject(this, Formatting.Indented);
        //}

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Transaction)obj);
        }

        /// <summary>
        /// Returns true if Transaction instances are equal
        /// </summary>
        /// <param name="other">Instance of Transaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Transaction other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return
                (
                    TransactionID == other.TransactionID ||
                    TransactionID != null &&
                    TransactionID.Equals(other.TransactionID)
                ) &&
                (
                    BuyerFirstName == other.BuyerFirstName ||
                    BuyerFirstName != null &&
                    BuyerFirstName.Equals(other.BuyerFirstName)
                ) &&
                (
                    BuyerLastName == other.BuyerLastName ||
                    BuyerLastName != null &&
                    BuyerLastName.Equals(other.BuyerLastName)
                ) &&
                (
                    BuyerAddress == other.BuyerAddress ||
                    BuyerAddress != null &&
                    BuyerAddress.Equals(other.BuyerAddress)
                ) &&
                (
                    BuyerCity == other.BuyerCity ||
                    BuyerCity != null &&
                    BuyerCity.Equals(other.BuyerCity)
                ) &&
                (
                    BuyerEmail == other.BuyerEmail ||
                    BuyerEmail != null &&
                    BuyerEmail.Equals(other.BuyerEmail)
                ) &&
                (
                    BuyerUserId == other.BuyerUserId ||
                    BuyerUserId != null &&
                    BuyerUserId.Equals(other.BuyerUserId)
                ) &&
                (
                    PaymentStatus == other.PaymentStatus ||
                    PaymentStatus != null &&
                    PaymentStatus.Equals(other.PaymentStatus)
                ) &&
                (
                    PaymentReference == other.PaymentReference ||
                    PaymentReference != null &&
                    PaymentReference.Equals(other.PaymentReference)
                ) &&
                (
                    TotalAmount == other.TotalAmount ||
                    TotalAmount != null &&
                    TotalAmount.Equals(other.TotalAmount)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (TransactionID != null)
                    hashCode = hashCode * 59 + TransactionID.GetHashCode();
                if (BuyerFirstName != null)
                    hashCode = hashCode * 59 + BuyerFirstName.GetHashCode();
                if (BuyerLastName != null)
                    hashCode = hashCode * 59 + BuyerLastName.GetHashCode();
                if (BuyerAddress != null)
                    hashCode = hashCode * 59 + BuyerAddress.GetHashCode();
                if (BuyerCity != null)
                    hashCode = hashCode * 59 + BuyerCity.GetHashCode();
                if (BuyerEmail != null)
                    hashCode = hashCode * 59 + BuyerEmail.GetHashCode();
                if (BuyerUserId != null)
                    hashCode = hashCode * 59 + BuyerUserId.GetHashCode();
                if (PaymentStatus != null)
                    hashCode = hashCode * 59 + PaymentStatus.GetHashCode();
                if (PaymentReference != null)
                    hashCode = hashCode * 59 + PaymentReference.GetHashCode();
                if (TotalAmount != null)
                    hashCode = hashCode * 59 + TotalAmount.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Transaction left, Transaction right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Transaction left, Transaction right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators

    }
}
