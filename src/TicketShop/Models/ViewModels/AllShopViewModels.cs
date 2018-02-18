using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.RestApiClient.Model;

namespace TicketShop.Models.ViewModels
{
    
    public class HomeIndexViewModel
    {
        public List<FullEventDate> FullEventDates { get; set; }
    }

    public class HomeEventViewModel
    {
        public Event Event { get; set; }
    }

    public class HomeEventsViewModel {
        public List<Event> Events { get; set; }       
    }

    public class HomeEventDateViewModel
    {
        public FullEventDate FullEventDate { get; set; }
    }

    public class HomeEventDatesViewModel
    {
        public List<FullEventDate> FullEventDates { get; set; }
    }

    public class HomeVenueViewModel
    {
        public Venue Venue { get; set; }
    }

    public class HomeVenuesViewModel
    {
        public List<Venue> Venues { get; set; }
    }
}
