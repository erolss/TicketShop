using System;

namespace TicketSystem.DatabaseRepository.Model
{
    public class EventDate
    {
        public int TicketEventDateID { get; set; }
        public int TicketEventID { get; set; }
        public int VenueId{get;set; }
        public DateTime EventStartDateTime { get; set; }
    }
}
