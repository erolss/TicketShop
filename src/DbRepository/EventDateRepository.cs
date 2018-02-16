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
                        VALUES(@eventDate)";
                        //VALUES(@eventId, @venueId, @eventStartDateTime, @price, @maxTickets)";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, eventDate);
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

        public List<EventDate> FindEventDates(string searchStr)
        {
            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venue v ON ted.VenueID = v.VenueID
                        WHERE te.EventName LIKE '%@searchQuery%'
                            OR te.EventHtmlDescription LIKE '%@searchQuery%'
                            OR v.VenueName LIKE '%@searchQuery%'
                            OR v.City LIKE '%@searchQuery%'
                            OR v.Country LIKE '%@searchQuery%'
                            OR ted.EventStartDateTime LIKE '%@searchQuery%'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query, new { searchQuery = searchStr }).ToList();

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
            var query = @"SELECT * FROM TicketEventDates
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

        public FullEventDate GetFullEventDateById(int id)
        {
            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.TicketEventID
                        JOIN Venue v ON ted.VenueID = v.VenueID
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
                venueId = eventDate.VenueId,
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
