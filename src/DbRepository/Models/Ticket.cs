using System;
using System.Text;
using System.Runtime.Serialization;

namespace TicketApi.Db.Models
{
    public partial class Ticket : IEquatable<Ticket>
    {
        /// <summary>
        /// Gets or Sets TicketId
        /// </summary>
        [DataMember(Name = "ticketId")]
        public int? TicketId { get; set; }

        /// <summary>
        /// Gets or Sets TicketEventDateId
        /// </summary>
        [DataMember(Name = "ticketEventDateId")]
        public int? TicketEventDateId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ticket {\n");
            sb.Append("  TicketId: ").Append(TicketId).Append("\n");
            sb.Append("  TicketEventDateId: ").Append(TicketEventDateId).Append("\n");
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
                    TicketId == other.TicketId ||
                    TicketId != null &&
                    TicketId.Equals(other.TicketId)
                ) &&
                (
                    TicketEventDateId == other.TicketEventDateId ||
                    TicketEventDateId != null &&
                    TicketEventDateId.Equals(other.TicketEventDateId)
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
                if (TicketId != null)
                    hashCode = hashCode * 59 + TicketId.GetHashCode();
                if (TicketEventDateId != null)
                    hashCode = hashCode * 59 + TicketEventDateId.GetHashCode();
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
