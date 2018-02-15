using System;

namespace TicketApi.Db.Model
{
    public class EventDate
    {
        public int TicketEventDateID { get; set; }
        public int TicketEventID { get; set; }
        public int VenueId{get;set; }
        public DateTime EventStartDateTime { get; set; }
        public double Price { get; set; }
        public int MaxTickets { get; set; }
    }
}
