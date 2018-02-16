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
    public partial class Venue : IEquatable<Venue>
    {
        /// <summary>
        /// Gets or Sets VenueID
        /// </summary>
        [DataMember(Name = "venueId")]
        public int? VenueID { get; set; }

        /// <summary>
        /// Gets or Sets VenueName
        /// </summary>
        [DataMember(Name = "venueName")]
        public string VenueName { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Venue {\n");
            sb.Append("  VenueID: ").Append(VenueID).Append("\n");
            sb.Append("  VenueName: ").Append(VenueName).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Venue)obj);
        }

        /// <summary>
        /// Returns true if Venue instances are equal
        /// </summary>
        /// <param name="other">Instance of Venue to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Venue other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return
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
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Venue left, Venue right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Venue left, Venue right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
   
}
