using Dapper;
using DbExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketApi.Db.Interface;
using TicketApi.Db.Models;

namespace TicketApi.Db
{
    public class EventDateRepository : IEventDateRepository
    {

        private readonly string _connectionString;

        public EventDateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public EventDate AddEventDate(EventDate eventDate)
        {
            var query = @"INSERT INTO TicketEventDates(TicketEventID, VenueID, EventStartDateTime, Price, MaxTickets)
                        VALUES(@TicketEventID, @VenueID, @EventStartDateTime, @Price, @MaxTickets)";
            //VALUES(@eventId, @venueId, @eventStartDateTime, @price, @maxTickets)";
            var values = new {
                TicketEventID = eventDate.TicketEventID,
                VenueID = eventDate.VenueID,
                EventStartDateTime = eventDate.EventStartDateTime,
                Price = eventDate.Price,
                MaxTickets = eventDate.MaxTickets
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, values );
                var addedItemQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                var result = connection.Query<EventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateID=@id", new { id = addedItemQuery }).FirstOrDefault();

                return result;

            }
        }

        public bool DeleteEventDate(int id)
        {
            var query = SQL
                .DELETE_FROM("TicketEventDates")
                .WHERE("TicketEventDateID = @id");

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

        public List<FullEventDate> FindFullEventDates(string searchStr)
        {
            var query = String.Format(@"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        WHERE te.EventName LIKE '%{0}%'
                            OR te.EventHtmlDescription LIKE '%{0}%'
                            OR v.VenueName LIKE '%{0}%'
                            OR v.City LIKE '%{0}%'
                            OR v.Country LIKE '%{0}%'
                            OR ted.EventStartDateTime LIKE '%{0}%'", searchStr);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FullEventDate>(query).ToList();

                return result;
            }
        }
        

        public int GetSoldTicketCount(int id)
        {

            var query = @"SELECT COUNT(TicketEventDateID)
                        FROM Tickets
                        GROUP BY TicketEventDateID
                        HAVING TicketEventDateID = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<int>(query, new { id }).First();

                return result;
            }
        }

        public EventDate GetEventDateByEventId(int eventId)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEventDates")
                .WHERE("TicketEventDateID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query.ToString(), new { id = eventId }).FirstOrDefault();

                return result;
            }
        }

        public EventDate GetEventDateById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEventDates")
                .WHERE("TicketEventDateID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query.ToString(), new { id }).FirstOrDefault();

                return result;
            }
        }

        public List<EventDate> GetEventDates(int offset = 0, int maxLimit = 20)
        {

            if (maxLimit > 30)
            {
                maxLimit = 30;
            }

            var query = @"SELECT * FROM TicketEventDates
                        WHERE EventStartDateTime > CURRENT_TIMESTAMP
                        ORDER BY EventStartDateTime ASC
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }
        public List<FullEventDate> GetFullEventDates(int offset = 0, int maxLimit = 20)
        {

            if (maxLimit > 30)
            {
                maxLimit = 30;
            }

            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        WHERE EventStartDateTime > CURRENT_TIMESTAMP
                        ORDER BY EventStartDateTime ASC
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FullEventDate>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }
        public List<FullEventDate> GetFullEventDatesByEventId(int eventId, int offset = 0, int maxLimit = 20)
        {

            if (maxLimit > 30)
            {
                maxLimit = 30;
            }

            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        WHERE ted.TicketEventID = @eventId AND EventStartDateTime > CURRENT_TIMESTAMP
                        ORDER BY EventStartDateTime ASC
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FullEventDate>(query, new { eventId, offset, maxLimit }).ToList();

                return result;
            }
        }
        

        public FullEventDate GetFullEventDateById(int id)
        {
            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venues v ON ted.VenueID = v.VenueID
                        WHERE ted.TicketEventDateID = @id";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<FullEventDate>(query, new { id }).FirstOrDefault();

                return result;
            }
        }


        public EventDate UpdateEventDate(EventDate eventDate)
        {
            var query = SQL
                .UPDATE("TicketEventDates")
                .SET("TicketEventID = @eventId, VenueID = @venueId, EventStartDateTime = @dateTime, Price = @price, MaxTickets = @maxTickets")
                .WHERE("TicketEventDateID = @id");

            var values = new
            {
                eventId = eventDate.TicketEventID,
                venueId = eventDate.VenueID,
                dateTime = eventDate.EventStartDateTime,
                price = eventDate.Price,
                maxTickets = eventDate.MaxTickets,
                id = eventDate.TicketEventDateID
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), values);
                var result = connection.Query<EventDate>("SELECT * FROM TicketEvents WHERE TicketEventId = @id", new { values.id }).First();

                return result;
            }
        }
    }
}
