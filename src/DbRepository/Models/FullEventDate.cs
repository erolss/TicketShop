using System;
using System.Runtime.Serialization;

namespace TicketApi.Db.Models
{
    [DataContract]
    public class FullEventDate
    {
        [DataMember]
        public int TicketEventDateID { get; set; }
        [DataMember]
        public int TicketEventID { get; set; }
        [DataMember]
        public string EventName { get; set; }
        [DataMember]
        public string EventHtmlDescription { get; set; }
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
    }
}
