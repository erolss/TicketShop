using System;

namespace TicketSystem.DbRepository.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public FullEventDate EventDate { get; set; }
        
    }
}
