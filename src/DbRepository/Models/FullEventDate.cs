using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace TicketApi.Db.Models
{
    [DataContract]
    public partial class FullEventDate : IEquatable<FullEventDate>
    {
        [DataMember]
        public int? TicketEventDateID { get; set; }
        [DataMember]
        public int TicketEventID { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public string EventHtmlDescription { get; set; }
        [DataMember]
        public string EventImagePath { get; set; }
        [DataMember]
        public int VenueID { get; set; }
        [DataMember]
        public string VenueName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public DateTime EventStartDateTime { get; set; }
        [DataMember]
        public double Price { get; set; }
        [DataMember]
        public int MaxTickets { get; set; }

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
            sb.Append("  EventName: ").Append(EventName).Append("\n");
            sb.Append("  EventHtmlDescription: ").Append(EventHtmlDescription).Append("\n");
            sb.Append("  EventImagePath: ").Append(EventImagePath).Append("\n");
            sb.Append("  VenueID: ").Append(VenueID).Append("\n");
            sb.Append("  VenueName: ").Append(VenueName).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FullEventDate)obj);
        }

        /// <summary>
        /// Returns true if EventDate instances are equal
        /// </summary>
        /// <param name="other">Instance of EventDate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FullEventDate other)
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
                    EventName == other.EventName ||
                    EventName != null &&
                    EventName.Equals(other.EventName)
                ) &&
                (
                    EventHtmlDescription == other.EventHtmlDescription ||
                    EventHtmlDescription != null &&
                    EventHtmlDescription.Equals(other.EventHtmlDescription)
                ) &&
                (
                    EventImagePath == other.EventImagePath ||
                    EventImagePath != null &&
                    EventImagePath.Equals(other.EventImagePath)
                ) &&
                (
                    VenueID == other.VenueID ||
                    VenueID != null &&
                    VenueID.Equals(other.VenueID)
                ) &&
                (
                    VenueName == other.VenueName ||
                    VenueName != null &&
                    VenueName.Equals(other.VenueName)
                ) &&
                (
                    Address == other.Address ||
                    Address != null &&
                    Address.Equals(other.Address)
                ) &&
                (
                    City == other.City ||
                    City != null &&
                    City.Equals(other.City)
                ) &&
                (
                    Country == other.Country ||
                    Country != null &&
                    Country.Equals(other.Country)
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
                if (EventName != null)
                    hashCode = hashCode * 59 + EventName.GetHashCode();
                if (EventHtmlDescription != null)
                    hashCode = hashCode * 59 + EventHtmlDescription.GetHashCode();
                if (EventImagePath != null)
                    hashCode = hashCode * 59 + EventImagePath.GetHashCode();
                if (VenueID != null)
                    hashCode = hashCode * 59 + VenueID.GetHashCode();
                if (VenueName != null)
                    hashCode = hashCode * 59 + VenueName.GetHashCode();
                if (Address != null)
                    hashCode = hashCode * 59 + Address.GetHashCode();
                if (City != null)
                    hashCode = hashCode * 59 + City.GetHashCode();
                if (Country != null)
                    hashCode = hashCode * 59 + Country.GetHashCode();
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

        public static bool operator ==(FullEventDate left, FullEventDate right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FullEventDate left, FullEventDate right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
