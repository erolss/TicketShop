﻿using System;

namespace TicketSystem.DatabaseRepository.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public FullEventDate EventDate { get; set; }
        
    }
}
