using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.RestApiClient.Model;

namespace TicketShop.Models.ViewModels
{

    public class HomeIndexViewModel
    {
        public List<FullEventDate> FullEventDates { get; set; }
    }


    /* Shop ViewModels */

   
    public class ShopEventsViewModel
    {
        public List<Event> Events { get; set; }
    }
       
    public class ShopEventDatesViewModel
    {
        public List<FullEventDate> FullEventDates { get; set; }
    }

    public class ShopVenueViewModel
    {
        public Venue Venue { get; set; }
    }

    public class ShopVenuesViewModel
    {
        public List<Venue> Venues { get; set; }
    }

    public class ShopFindViewModel
    {
        public List<Event> Events { get; set; }
        public List<FullEventDate> FullEventDates { get; set; }
        public List<Venue> Venues { get; set; }
        public string PartialView { get; set; }
    }


    public class OrderCartViewModel {

        public List<FullEventDate> Events { get; set; }

        public double Total { get; set; }
        public string Currency { get; set; }
        public int? TransactionID { get; set; }
        
        public string BuyerLastName { get; set; }

        public string BuyerFirstName { get; set; }

        public string BuyerAddress { get; set; }

        public string BuyerCity { get; set; }

        public string PaymentStatus { get; set; }
        
        public string PaymentReference { get; set; }
        [Required]
        [EmailAddress]
        public string BuyerEmail { get; set; }
        
        public string BuyerUserId { get; set; }
        
        public double? TotalAmount { get; set; }
        public int? NumberTickets { get; set; }


    }

}
