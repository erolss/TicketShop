using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;


namespace TicketSystem.RestApiClient.Model
{
   
    public class Event
    {
        /// <summary>
        /// Gets or Sets TicketEventId
        /// </summary>       
        public int TicketEventID { get; set; }

        /// <summary>
        /// Gets or Sets EventName
        /// </summary>       
        public string EventName { get; set; }

        /// <summary>
        /// Gets or Sets EventHtmlDescription
        /// </summary>       
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
        
    }
}
