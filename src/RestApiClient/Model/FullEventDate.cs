using Newtonsoft.Json;
using System;
using System.Text;

namespace TicketSystem.RestApiClient.Model
{
    public class FullEventDate
    {
       
        public int TicketEventDateID { get; set; }
        public int TicketEventID { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime EventStartDateTime { get; set; }
        public double Price { get; set; }
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
        
    }
}
