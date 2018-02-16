using System;

namespace TicketApi.Db.Models
{
    public class FullTicket
    {
        public int TicketId { get; set; }
        public FullEventDate EventDate { get; set; }

    }
}
