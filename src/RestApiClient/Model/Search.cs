using Newtonsoft.Json;
using System.Text;

namespace TicketSystem.RestApiClient.Model {

    public class Search
    {
        /// <summary>
        /// Gets or Sets Searchstring
        /// </summary>
        public string Searchstring { get; set; }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Search {\n");
            sb.Append("  Searchstring: ").Append(Searchstring).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
        
    }
}
