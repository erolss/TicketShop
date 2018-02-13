using TicketSystem.DatabaseRepository.Model;
using System.Collections.Generic;

namespace TicketSystem.DatabaseRepository.Interface
{
    public interface ITicketRepository
    {
        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <returns>A list of Tickets</returns>
        List<Ticket> GetTickets();

        /// <summary>
        /// Get ticket by Id
        /// </summary>
        /// <param name="id">Id of the ticket</param>
        /// <returns>An object representing the ticket</returns>
        Ticket GetTicketById(int id);
    }
}
