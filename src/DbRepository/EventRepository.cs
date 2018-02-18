using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TicketApi.Db.Interface;
using TicketApi.Db.Models;
using Dapper;
using DbExtensions;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace TicketApi.Db
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString;

        public EventRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Event AddEvent(Event item)
        {

            var query = @"INSERT INTO TicketEvents(EventName, EventHtmlDescription, EventImagePath)
                        VALUES(@name, @htmlDescription, @imgPath)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, new { name = item.EventName, htmlDescription = item.EventHtmlDescription, imgPath = item.EventImagePath});
                var addedTicketEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                var result = connection.Query<Event>("SELECT * FROM TicketEvents WHERE TicketEventID=@id", new { id = addedTicketEventQuery }).First();

                return result;

            }
        }

        public bool DeleteEvent(int id)
        {
            var query = SQL
                .DELETE_FROM("TicketEvents")
                .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if (connection.Execute(query.ToString(), new { id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }



        public Event GetEventById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEvents")
                .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query.ToString(), new { id }).FirstOrDefault();

                return result;
            }
        }

        public List<Event> GetEvents(int offset = 0, int maxLimit = 20)
        {
            if (maxLimit > 30)
            {
                maxLimit = 30;
            }

            var query = @"SELECT * FROM TicketEvents
                        ORDER BY TicketEventID DESC
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }

        public Event UpdateEvent(Event item)
        {
            var query = SQL
                .UPDATE("TicketEvents")
                .SET("EventName = @name, EventHtmlDescription = @htmlDescription, EventImagePath = @imgPath")
                .WHERE("TicketEventID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { name = item.EventName, htmlDescription = item.EventHtmlDescription, imgPath = item.EventImagePath, id = item.TicketEventID});
                var result = connection.Query<Event>("SELECT * FROM TicketEvents WHERE TicketEventID = @id", new { id = item.TicketEventID }).FirstOrDefault();

                return result;

            }
        }

        public List<Event> FindEvents(string searchStr)
        {


            var query = String.Format(@"SELECT * FROM TicketEvents
                        WHERE EventName like '%{0}%' OR
                        EventHtmlDescription like '%{0}%'", searchStr);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Event>(query).ToList();

                return result;
            }
        }
    }
}
