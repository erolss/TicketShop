using System;
using System.Runtime.Serialization;

namespace TicketApi.Db.Models
{
    [DataContract]
    public class FullTicket
    {
        [DataMember]
        public int TicketID { get; set; }

        [DataMember]
        public FullEventDate EventDate { get; set; }

    }
}
