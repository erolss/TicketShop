using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TicketSystem.DatabaseRepository.Interface;
using TicketSystem.DatabaseRepository.Model;
using Dapper;
using DbExtensions;
using System.Linq;

namespace TicketSystem.DatabaseRepository
{
    public class EventRepository : IEventRepository
    {
       
        public Event AddEvent(string name, string htmlDescription)
        {
            var query = @"INSERT INTO TicketEvents(EventName, EventHtmlDescription)
                        VALUES(@name, @htmlDescription)";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query(query, new { name, htmlDescription });
                var addedTicketEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                var result = connection.Query<Event>("SELECT * FROM TicketEvents WHERE TicketEventID=@id", new { id = addedTicketEventQuery }).First();

                return result;

            }
        }

        public void DeleteEvent(int id)
        {
            var query = SQL
                .DELETE_FROM("TicketEvents")
                .WHERE("TicketEventID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { id });
            }
        }

       

        public Event GetEventById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEvents")
                .WHERE("TicketEventID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query.ToString(), new { id }).First();

                return result;
            }
        }

        public List<Event> GetEvents(int offset = 0, int maxLimit = 20)
        {
            var query = @"SELECT * FROM TicketEvents
                        ORDER BY TicketEventID
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";


            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }

        public Event UpdateEvent(int id, string name, string htmlDescription)
        {
            var query = SQL
                .UPDATE("TicketEvents")
                .SET("EventName = @name, EventHtmlDescription = @htmlDescription")
                .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { name, htmlDescription });
                var result = connection.Query<Event>("SELECT * FROM TicketEvents WHERE EventID= @id", new { id }).First();

                return result;

            }
        }

        public List<Event> FindEvents(string searchStr)
        {
            var query = @"SELECT * FROM TicketEvents
                        WHERE EventName like '%@searchQuery%' OR EventHtmlDescription like '%@searchQuery%'";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query, new { searchQuery = searchStr }).ToList();

                return result;
            }
        }
    }
}
