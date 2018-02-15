using System;

namespace TicketApi.Db.Model
{
    public class FullEventDate
    {
        public int TicketEventDateId { get; set; }
        public int TicketEventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime EventStartDateTime { get; set; }
        public double Price { get; set; }
        public int MaxTickets { get; set; }
    }
}
