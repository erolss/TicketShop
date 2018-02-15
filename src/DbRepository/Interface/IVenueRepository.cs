using System;
using System.Collections.Generic;
using System.Text;
using TicketApi.Db.Model;

namespace TicketApi.Db.Interface
{
    public interface IVenueRepository
    {
        /// <summary>
        /// Add a new venue to the database
        /// </summary>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Physical address of the venue</param>
        /// <param name="city">City part of the adress</param>
        /// <param name="country">Country part of the adress</param>
        /// <returns>An object representing the newly created Venue</returns>
        Venue AddVenue(string name, string address, string city, string country);
        
        /// <summary>
        /// Delete a venue
        /// </summary>
        /// <param name="id">ID of venue to delete</param>
        void DeleteVenue(int id);

        /// <summary>
        /// Get venue by ID
        /// </summary>
        /// <param name="id">ID of venue to get</param>
        /// <returns>An object representation of the Venue with corresponding ID</returns>
        Venue GetVenueById(int id);

        /// <summary>
        /// Get list of venues
        /// </summary>
        /// <param name="offset">Result list offset</param>
        /// <param name="limit">Number to limit the results to</param>
        /// <returns>A list of objects limited to the number of param limit, starting at result with number of param offset</returns>
        List<Venue> GetVenues(int offset = 0, int maxLimit = 20);

        /// <summary>
        /// Update a venue
        /// </summary>
        /// <param name="id">ID of the venue to update</param>
        /// <param name="name">Name of the venue</param>
        /// <param name="address">Address of the venue</param>
        /// <param name="city">Venue city</param>
        /// <param name="country">Venue country</param>
        /// <returns>An object representation of the updated Venue</returns>
        Venue UpdateVenue(int id, string name, string address, string city, string country );

        /// <summary>
        /// Find all venues matching the search string
        /// </summary>
        /// <param name="searchString">A text string to search for a venue</param>
        /// <returns>A list of object Venue matching the search string</returns>
        List<Venue> FindVenue(string searchStr);
    }
}
