using System;

namespace TicketSystem.DatabaseRepository.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public int TicketEventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int TicketEventDateId { get; set; }
        public int VenueId { get; set; }
        public DateTime EventStartDateTime { get; set; }
    }
}
