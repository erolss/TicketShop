using System;

namespace TicketSystem.DatabaseRepository.Model
{
    public class FullEventDate
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventHtmlDescription { get; set; }
        public int EventDateId { get; set; }
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueCity { get; set; }
        public string VenueCountry { get; set; }
        public DateTime EventStartDateTime { get; set; }
        
    }
}
