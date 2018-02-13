using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TicketSystem.DatabaseRepository.Model;
using TicketSystem.DatabaseRepository.Interface;
using DbExtensions;

namespace TicketSystem.DatabaseRepository
{
    public class TicketRepository : ITicketRepository
    {

        public List<Ticket> GetTickets(int offset = 0, int maxLimit = 20)
        {

            var query = @"SELECT * FROM
                        ";
            //SELECT*
            //FROM Tickets t
            //JOIN SeatsAtEventDate s ON t.SeatID = s.SeatID
            //JOIN TicketEventDates tad ON s.TicketEventDateID = tad.TicketEventDateID
            //JOIN Venues v ON tad.VenueID = v.VenueID
            //JOIN TicketEvents te ON tad.TicketEventID = te.TicketEventID
            //WHERE TicketID = 1

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { name, description });
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID = @id", new { id }).First();
            }

        }

        public List<Ticket> GetTicketsByUserId(string userId, int offset = 0, int maxLimit = 20)
        {

        }

        public List<Ticket> GetTicketsByTransactionId(int transactionId, int offset = 0, int maxLimit = 20)
        {
            
        }

        public Ticket GetTicketById(int id)
        {

        }

        
    }
}
