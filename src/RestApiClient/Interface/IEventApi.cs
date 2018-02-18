using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.RestApiClient.Model;

namespace TicketShop.RestApiClient.Interface
{
    public interface IEventApi
    {

        /// <summary>
        /// Add Event to database
        /// </summary>
        /// <param name="item">Event object</param>
        /// <returns>An Object representation of newly created event</returns>
        Event AddEvent(Event item);

        /// <summary>
        /// Get all events, w offset & limit
        /// </summary>
        /// <param name="offset">Result offset</param>
        /// <param name="maxLimit">Max no result rows to fetch</param>
        /// <returns>A list of object representations of Events</returns>
        List<Event> GetEvents(int offset = 0, int maxLimit = 20);

        /// <summary>
        /// Get Event by Id
        /// </summary>
        /// <param name="id">Event Id</param>
        /// <returns>An Object representation of the event</returns>
        Event GetEventById(int id);

        /// <summary>
        /// Update event by Id
        /// </summary>
        /// <param name="item">Event object</param>
        /// <returns>>An Object representation of the updated event</returns>
        Event UpdateEvent(Event item);

        /// <summary>
        /// Delete Event by Id
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <returns>bool, true if delete succeeded</returns>
        bool DeleteEvent(int id);

        /// <summary>
        /// Find Events by search query
        /// </summary>
        /// <param name="query">Search object</param>
        /// <returns>A list of object representations of Events matching the search query</returns>
        List<Event> FindEvents(Search query);

    }
}
