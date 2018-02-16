using System;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TicketApi.Db.Models
{
    [DataContract]
    public partial class FullTicket :IEquatable<FullTicket>
    {
        [DataMember]
        public int TicketID { get; set; }

        [DataMember]
        public FullEventDate EventDate { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ticket {\n");
            sb.Append("  TicketID: ").Append(TicketID).Append("\n");
            sb.Append("  EventDate: ").Append(EventDate).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FullTicket)obj);
        }

        /// <summary>
        /// Returns true if Ticket instances are equal
        /// </summary>
        /// <param name="other">Instance of Ticket to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FullTicket other)
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
                    EventDate == other.EventDate ||
                    EventDate != null &&
                    EventDate.Equals(other.EventDate)
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
                if (EventDate != null)
                    hashCode = hashCode * 59 + EventDate.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FullTicket left, FullTicket right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FullTicket left, FullTicket right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators

    }
}
