using System;
using System.Collections.Generic;
using TicketSystem.DatabaseRepository.Model;

namespace TicketSystem.DatabaseRepository.Interface
{
    public interface IEventDateRepository
    {
        
        /// <summary>
        /// Add event date to database
        /// </summary>
        /// <param name="eventId">ID of Event</param>
        /// <param name="venueId">ID of Venue where event date will take place</param>
        /// <param name="eventDate">Datetime of the event date</param>
        /// <param name="price">Price of a ticket to the EventDate</param>
        /// <param name="maxTickets">Max number of Tickets</param>
        /// <returns>An object representation of the created EventDate</returns>
        EventDate AddEventDate(int eventId, int venueId, DateTime eventDate, double price, int maxTickets );

        /// <summary>
        /// Get Event Dates
        /// </summary>
        /// <param name="offset">Result set offset</param>
        /// <param name="maxLimit">Max result rows to fetch</param>
        /// <returns>A list of object representations of EventDates</returns>
        List<EventDate> GetEventDates(int offset = 0, int maxLimit = 20);

        /// <summary>
        /// Get EventDate by ID
        /// </summary>
        /// <param name="id">ID of EventDate</param>
        /// <returns>An object representation of the EventDate</returns>
        EventDate GetEventDateById(int id);

        /// <summary>
        /// Get EventDate by parent Event ID
        /// </summary>
        /// <param name="eventId">ID of Parent Event</param>
        /// <returns>An object representation of the EventDate</returns>
        EventDate GetEventDateByEventId(int eventId);

        /// <summary>
        /// Get the full EventDate w/ all data of venue, event
        /// </summary>
        /// <param name="id">ID of the EventDate</param>
        /// <returns>An object representation of the EventDate</returns>
        FullEventDate GetFullEventDateById(int id);

        /// <summary>
        /// Update the EventDate
        /// </summary>
        /// <param name="id">ID of the EventDate</param>
        /// <param name="eventId">ID of parent Event</param>
        /// <param name="venueId">ID of venue</param>
        /// <param name="datetime">datetime of the EventDate</param>
        /// <param name="seats">Number of seats at EventDate</param>
        /// <returns>An object representation of the updated EventDate</returns>
        EventDate UpdateEventDate(int id, int eventId, int venueId, DateTime dateTime, double price, int maxTickets);

        /// <summary>
        /// Delete EventDate by ID
        /// </summary>
        /// <param name="id">ID of the EventDate</param>
        void DeleteEventDate(int id);

        /// <summary>
        /// Find EventDates matching the search query
        /// </summary>
        /// <param name="searchStr">Search query</param>
        /// <returns>A list of object representations of EventDates matching the query</returns>
        List<EventDate> FindEventDates(string searchStr);

              
        /// <summary>
        /// Get number of available seats at EventDate
        /// </summary>
        /// <param name="id">ID of EventDate</param>
        /// <returns>Number of available seats at EventDate</returns>
        int GetSoldTicketCount(int id);


    }
}
