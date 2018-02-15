using System;

namespace TicketApi.Db.Model
{
    public class FullTicket
    {
        public int TicketId { get; set; }
        public FullEventDate EventDate { get; set; }

    }
}
