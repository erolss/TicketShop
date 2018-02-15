using TicketSystem.DbRepository.Model;
using System.Collections.Generic;

namespace TicketSystem.DbRepository.Interface
{
    public interface ITicketRepository
    {
        /// <summary>
        /// Add new ticket
        /// </summary>
        /// <param name="ticket">Ticket object</param>
        /// <return>An object representation of the created ticket</returns>
        Ticket AddTicket(int ticketEventDateId);

        /// <summary>
        /// Update a ticket
        /// </summary>
        /// <param name="ticket">Ticket object</param>
        /// <returns>An object representation of the updated ticket</returns>
        Ticket UpdateTicket(int ticketId, int ticketEventDateId);

        /// <summary>
        /// Delete a ticket
        /// </summary>
        /// <param name="ticket">Ticket object</param>
        /// <returns>bool, true if deleted, false if not </returns>
        bool DeleteTicket(int ticketId);

        /// <summary>
        /// Get tickets
        /// </summary>
        /// <param name="offset">Result set offset</param>
        /// <param name="maxLimit">Max number of result to fetch</param>
        /// <returns>A list of ticket object representations</returns>
        List<Ticket> GetTickets(int offset = 0, int maxLimit = 20);

        /// <summary>
        /// Get tickets from user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="offset">Result set offset</param>
        /// <param name="maxLimit">Max number of result to fetch</param>
        /// <returns>A list of ticket object representations for user</returns>
        List<Ticket> GetTicketsByUserId(string userId, int offset = 0, int maxLimit = 20);

        /// <summary>
        /// Get tickets by transactionID
        /// </summary>
        /// <param name="transactionId">Transaction ID to look for</param>
        /// <param name="offset">Result set offset</param>
        /// <param name="maxLimit">Max number of result to fetch</param>
        /// <returns>A list of ticket object representations for a Transaction</returns>
        List<Ticket> GetTicketsByTransactionId(int transactionId, int offset = 0, int maxLimit = 20);
        /// <summary>
        /// Get ticket by Id
        /// </summary>
        /// <param name="id">Id of the ticket</param>
        /// <returns>An object representation of the ticket</returns>
        Ticket GetTicketById(int id);

        FullTicket GetFullTicketById(int id);
        List<FullTicket> GetFullTicketsByTransactionId(int transactionId);



    }
}
