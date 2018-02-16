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
    public partial class Event : IEquatable<Event>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "ticketEventID")]
        public int? TicketEventID { get; set; }

        /// <summary>
        /// Gets or Sets EventName
        /// </summary>
        [DataMember(Name = "eventName")]
        public string EventName { get; set; }

        /// <summary>
        /// Gets or Sets EventHtmlDescription
        /// </summary>
        [DataMember(Name = "eventHtmlDescription")]
        public string EventHtmlDescription { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Event {\n");
            sb.Append("  TicketEventID: ").Append(TicketEventID).Append("\n");
            sb.Append("  EventName: ").Append(EventName).Append("\n");
            sb.Append("  EventHtmlDescription: ").Append(EventHtmlDescription).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Event)obj);
        }

        /// <summary>
        /// Returns true if Event instances are equal
        /// </summary>
        /// <param name="other">Instance of Event to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Event other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return
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
                if (TicketEventID != null)
                    hashCode = hashCode * 59 + TicketEventID.GetHashCode();
                if (EventName != null)
                    hashCode = hashCode * 59 + EventName.GetHashCode();
                if (EventHtmlDescription != null)
                    hashCode = hashCode * 59 + EventHtmlDescription.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Event left, Event right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Event left, Event right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
