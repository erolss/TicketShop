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

        public List<Ticket> GetTickets()
        {

            var query = new SqlBuilder()
            .UPDATE("TicketEvents")
            .SET("EventName = @name, EventHtmlDescription = @description")
            .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { name, description });
                return connection.Query<TicketEvent>("SELECT * FROM TicketEvents WHERE TicketEventID = @id", new { id }).First();
            }

        }

        public Ticket GetTicketById(int id)
        {

        }




    }
}
