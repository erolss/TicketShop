using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.RestApiClient.Model;

namespace TicketShop.Areas.Admin.Models
{
    public class EventsViewModel
    {
        public List<Event> Events { get; set; }
    }
    public class EventViewModel
    {
        public int TicketEventID { get; set; }
       
        public string EventName { get; set; }
            
        public string EventHtmlDescription { get; set; }
        
        public string EventImagePath { get; set; }
    }

    public class EventDatesViewModel
    {
        public List<EventDate> EventDates { get; set; }
    }

    public class VenuesViewModel
    {
        public List<Venue> Venues { get; set; }
    }

    public class FindViewModel
    {
        public List<Event> Events { get; set; }
        public List<EventDate> EventDates { get; set; }
        public List<Venue> Venues { get; set; }
        public string PartialView { get; set; }
        public string SearchParam { get; set; }
    }

}
