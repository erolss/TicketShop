using System;
using System.Collections.Generic;
using System.Text;
using TicketApi.Db.Models;

namespace TicketApi.Db.Interface
{
    public interface IEventRepository
    {   
        
        /// <summary>
        /// Add Event to database
        /// </summary>
        /// <param name="name">Event name</param>
        /// <param name="htmlDescription">Event html description</param>
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
        /// <param name="id">Event Id</param>
        /// <param name="name">Event name</param>
        /// <param name="htmlDescription">Event html description</param>
        /// <returns>>An Object representation of the updated event</returns>
        Event UpdateEvent(Event item);

        /// <summary>
        /// Delete Event by Id
        /// </summary>
        /// <param name="id">Event ID</param>
        void DeleteEvent(int id);

        /// <summary>
        /// Find Events by search query
        /// </summary>
        /// <param name="searchStr">Search query</param>
        /// <returns>A list of object representations of Events matching the search query</returns>
        List<Event> FindEvents(string searchStr);

    }
}
