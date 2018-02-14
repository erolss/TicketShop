using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;
using TicketSystem.DatabaseRepository.Interface;


namespace TicketSystem.DatabaseRepository
{
    public class TicketRepository : ITicketRepository
    {

        public List<Ticket> GetTickets(int offset = 0, int maxLimit = 20)
        {

            //var query = @"SELECT * FROM
            //            ";
            ////SELECT*
            ////FROM Tickets t
            ////JOIN SeatsAtEventDate s ON t.SeatID = s.SeatID
            ////JOIN TicketEventDates tad ON s.TicketEventDateID = tad.TicketEventDateID
            ////JOIN Venues v ON tad.VenueID = v.VenueID
            ////JOIN TicketEvents te ON tad.TicketEventID = te.TicketEventID
            ////WHERE TicketID = 1

            //using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            //{
            //    connection.Open();
            //    connection.Execute(query.ToString(), new { name, description });
            //    return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID = @id", new { id }).First();
            //}
            throw new System.NotImplementedException();

        }

        public List<Ticket> GetTicketsByUserId(string userId, int offset = 0, int maxLimit = 20)
        {
            var query = @"SELECT * FROM TicketTransactions t
                        JOIN TicketToTransactions ttt ON t.TransactionID = ttt.TransactionID
                        JOIN Tickets ON ttt.TicketID = Tickets.TicketID
                        JOIN SeatsAtEventDate ON Tickets.SeatID = SeatsAtEventDate.SeatID
                        JOIN TicketEventDates ted ON SeatsAtEventDate.TicketEventDateID = ted.TicketEventDateID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        JOIN TicketEvent te ON ted.TicketEventID = te.TicketEventID
                        WHERE t.BuyerUserId = @userId
                        ORDER BY TransactionID
                        OFFSET @offset ROWS
                        FETCH @maxLimit ROWS ONLY";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Ticket>(query, new { userId, offset, maxLimit }).ToList();

                return result;
            }
        }

        public List<Ticket> GetTicketsByTransactionId(int transactionId, int offset = 0, int maxLimit = 20)
        {
            var query = @"SELECT Tickets.TicketID, Tickets.TicketEventDateID FROM TicketTransactions t
                        JOIN TicketToTransactions ttt ON t.TransactionID = ttt.TransactionID
                        JOIN Tickets ON ttt.TicketID = Tickets.TicketID
                        WHERE t.TransActionID = @transactionId
                        ORDER BY Tickets.TicketID
                        OFFSET @offset ROWS
                        FETCH @maxLimit ROWS ONLY";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Ticket>(query, new { transactionId, offset, maxLimit }).ToList();

                return result;
            }
        }

        public Ticket GetTicketById(int id)
        {
            var query = @"SELECT * FROM Tickets WHERE TicketID = @ticketId";


            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<Ticket>(query, new { ticketId = id }).First();

                return result;
            }
        }

        public FullTicket GetFullTicketById(int id)
        {
            var query = @"SELECT * FROM Tickets t
                        JOIN TicketToTransactions ttt ON t.TicketID = ttt.TicketID
                        JOIN TicketsTransactions tt ON ttt.TransactionID = tt.TransactionID
                        JOIN SeatsAtEventDate ON Tickets.SeatID = SeatsAtEventDate.SeatID
                        JOIN TicketEventDates ted ON SeatsAtEventDate.TicketEventDateID = ted.TicketEventDateID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        JOIN TicketEvent te ON ted.TicketEventID = te.TicketEventID
                        WHERE t.TicketID = @ticketId";


            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<FullTicket>(query, new { ticketId = id }).First();

                return result;
            }
        }

        public List<FullTicket> GetFullTicketsByTransactionId(int transactionId)
        {
            var query = @"SELECT * FROM TicketTransactions t
                        JOIN TicketToTransactions ttt ON t.TransactionID = ttt.TransactionID
                        JOIN Tickets ON ttt.TicketID = Tickets.TicketID
                        JOIN SeatsAtEventDate ON Tickets.SeatID = SeatsAtEventDate.SeatID
                        JOIN TicketEventDates ted ON SeatsAtEventDate.TicketEventDateID = ted.TicketEventDateID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        JOIN TicketEvent te ON ted.TicketEventID = te.TicketEventID
                        WHERE t.TransActionID = @transactionId
                        ORDER BY Tickets.TicketID";

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                var result = connection.Query<FullTicket>(query, new { transactionId }).ToList();

                return result;
            }
        }
    }
}
