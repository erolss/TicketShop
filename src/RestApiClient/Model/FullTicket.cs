using Newtonsoft.Json;
using System.Text;

namespace TicketShop.RestApiClient.Model
{
    public class FullTicket
    {
      
        public int TicketID { get; set; }
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
        
    }
}
