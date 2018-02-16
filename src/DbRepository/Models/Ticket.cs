using System;
using System.Text;
using System.Runtime.Serialization;

namespace TicketApi.Db.Models
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Ticket : IEquatable<Ticket>
    {
        /// <summary>
        /// Gets or Sets TicketID
        /// </summary>
        [DataMember(Name = "ticketID")]
        public int? TicketID { get; set; }

        /// <summary>
        /// Gets or Sets TicketEventDateID
        /// </summary>
        [DataMember(Name = "ticketEventDateID")]
        public int? TicketEventDateID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ticket {\n");
            sb.Append("  TicketID: ").Append(TicketID).Append("\n");
            sb.Append("  TicketEventDateID: ").Append(TicketEventDateID).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Ticket)obj);
        }

        /// <summary>
        /// Returns true if Ticket instances are equal
        /// </summary>
        /// <param name="other">Instance of Ticket to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Ticket other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return
                (
                    TicketID == other.TicketID ||
                    TicketID != null &&
                    TicketID.Equals(other.TicketID)
                ) &&
                (
                    TicketEventDateID == other.TicketEventDateID ||
                    TicketEventDateID != null &&
                    TicketEventDateID.Equals(other.TicketEventDateID)
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
                if (TicketID != null)
                    hashCode = hashCode * 59 + TicketID.GetHashCode();
                if (TicketEventDateID != null)
                    hashCode = hashCode * 59 + TicketEventDateID.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Ticket left, Ticket right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Ticket left, Ticket right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators

    }
}
