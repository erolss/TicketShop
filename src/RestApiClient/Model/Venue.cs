using Newtonsoft.Json;
using System.Text;

namespace TicketShop.RestApiClient.Model
{
    public class Venue
    {
        /// <summary>
        /// Gets or Sets VenueID
        /// </summary>
        public int? VenueID { get; set; }

        /// <summary>
        /// Gets or Sets VenueName
        /// </summary>
        public string VenueName { get; set; }

        /// <summary>
        /// Gets or Sets Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
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
        
    }
   
}
