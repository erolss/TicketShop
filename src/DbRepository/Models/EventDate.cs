using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace TicketApi.Db.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class EventDate : IEquatable<EventDate>
    {
        /// <summary>
        /// Gets or Sets TicketEventDateID
        /// </summary>
        [DataMember(Name = "ticketEventDateID")]
        public int? TicketEventDateID { get; set; }

        /// <summary>
        /// Gets or Sets TicketEventId
        /// </summary>
        [DataMember(Name = "ticketEventID")]
        public int? TicketEventID { get; set; }

        /// <summary>
        /// Gets or Sets VenueID
        /// </summary>
        [DataMember(Name = "venueID")]
        public int? VenueID { get; set; }

        /// <summary>
        /// Gets or Sets EventStartDateTime
        /// </summary>
        [DataMember(Name = "eventStartDateTime")]
        public DateTime EventStartDateTime { get; set; }

        /// <summary>
        /// Gets or Sets MacTickets
        /// </summary>
        [DataMember(Name = "maxTickets")]
        public int? MaxTickets { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        [DataMember(Name = "price")]
        public double? Price { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EventDate {\n");
            sb.Append("  TicketEventDateID: ").Append(TicketEventDateID).Append("\n");
            sb.Append("  TicketEventID: ").Append(TicketEventID).Append("\n");
            sb.Append("  VenueID: ").Append(VenueID).Append("\n");
            sb.Append("  EventStartDateTime: ").Append(EventStartDateTime).Append("\n");
            sb.Append("  MaxTickets: ").Append(MaxTickets).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EventDate)obj);
        }

        /// <summary>
        /// Returns true if EventDate instances are equal
        /// </summary>
        /// <param name="other">Instance of EventDate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EventDate other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return
                (
                    TicketEventDateID == other.TicketEventDateID ||
                    TicketEventDateID != null &&
                    TicketEventDateID.Equals(other.TicketEventDateID)
                ) &&
                (
                    TicketEventID == other.TicketEventID ||
                    TicketEventID != null &&
                    TicketEventID.Equals(other.TicketEventID)
                ) &&
                (
                    VenueID == other.VenueID ||
                    VenueID != null &&
                    VenueID.Equals(other.VenueID)
                ) &&
                (
                    EventStartDateTime == other.EventStartDateTime ||
                    EventStartDateTime != null &&
                    EventStartDateTime.Equals(other.EventStartDateTime)
                ) &&
                (
                    MaxTickets == other.MaxTickets ||
                    MaxTickets != null &&
                    MaxTickets.Equals(other.MaxTickets)
                ) &&
                (
                    Price == other.Price ||
                    Price != null &&
                    Price.Equals(other.Price)
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
                if (TicketEventDateID != null)
                    hashCode = hashCode * 59 + TicketEventDateID.GetHashCode();
                if (TicketEventID != null)
                    hashCode = hashCode * 59 + TicketEventID.GetHashCode();
                if (VenueID != null)
                    hashCode = hashCode * 59 + VenueID.GetHashCode();
                if (EventStartDateTime != null)
                    hashCode = hashCode * 59 + EventStartDateTime.GetHashCode();
                if (MaxTickets != null)
                    hashCode = hashCode * 59 + MaxTickets.GetHashCode();
                if (Price != null)
                    hashCode = hashCode * 59 + Price.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(EventDate left, EventDate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EventDate left, EventDate right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
