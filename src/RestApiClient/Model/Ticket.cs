using Newtonsoft.Json;
using System.Text;

namespace TicketShop.RestApiClient.Model
{
    public class Ticket
    {
        /// <summary>
        /// Gets or Sets TicketID
        /// </summary>
        public int TicketID { get; set; }

        /// <summary>
        /// Gets or Sets TicketEventDateID
        /// </summary>
        public int TicketEventDateID { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Ticket {\n");
            sb.Append("  TicketID: ").Append(TicketID).Append("\n");
            sb.Append("  TicketEventDateID: ").Append(TicketEventDateID).Append("\n");
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
