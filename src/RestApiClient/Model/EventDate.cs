using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    
    public class EventDate
    {
        /// <summary>
        /// Gets or Sets TicketEventDateID
        /// </summary>
        public int TicketEventDateID { get; set; }

        /// <summary>
        /// Gets or Sets TicketEventId
        /// </summary>
        public int TicketEventID { get; set; }

        /// <summary>
        /// Gets or Sets VenueID
        /// </summary>
        public int VenueID { get; set; }

        /// <summary>
        /// Gets or Sets EventStartDateTime
        /// </summary>
        public DateTime EventStartDateTime { get; set; }

        /// <summary>
        /// Gets or Sets MacTickets
        /// </summary>
        public int MaxTickets { get; set; }

        /// <summary>
        /// Gets or sets Price
        /// </summary>
        public double Price { get; set; }

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
        
    }
}
