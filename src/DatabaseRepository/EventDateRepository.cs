using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.DatabaseRepository.Interface;
using TicketSystem.DatabaseRepository.Model;
using Dapper;
using DbExtensions;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace TicketSystem.DatabaseRepository
{
    public class EventDateRepository : IEventDateRepository
    {
        public EventDate AddEventDate(int eventId, int venueId, DateTime eventDate)
        {
            var query = @"INSERT INTO TicketEventDates(TicketEventID, VenueId, EventStartDateTime)
                        VALUES(@eventId, @venueId, @eventStartDateTime)";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query(query, new { eventId, venueId, eventStartDateTime = eventDate });
                var addedItemQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEventDates') AS Current_Identity").First();
                var result = connection.Query<EventDate>("SELECT * FROM TicketEventDates WHERE TicketEventDateId=@id", new { id = addedItemQuery }).First();

                return result;

            }
        }

        public void AddSeats(int id, int numberSeats)
        {
            var query = @"INSERT INTO SeatsAtTicketEvent(EventName, EventHtmlDescription)
                        VALUES(@name, @htmlDescription)";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query(query, new { name, htmlDescription });
                var addedTicketEventQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketEvents') AS Current_Identity").First();
                var result = connection.Query<Event>("SELECT * FROM TicketEvents WHERE EventID=@id", new { id = addedTicketEventQuery }).First();

                return result;

            }
        }

        public void DeleteEventDate(int id)
        {
            var query = SQL
                .DELETE_FROM("TicketEventDates")
                .WHERE("TicketEventDateID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { id });
            }
        }

        public List<EventDate> FindEventDates(string searchStr)
        {
            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.EventId
                        JOIN Venue v ON ted.VenueId = v.VenueID
                        WHERE te.EventName LIKE '%@searchQuery%'
                            OR te.EventHtmlDescription LIKE '%@searchQuery%'
                            OR v.VenueName LIKE '%@searchQuery%'
                            OR v.City LIKE '%@searchQuery%'
                            OR v.Country LIKE '%@searchQuery%'
                            OR ted.EventStartDateTime LIKE '%@searchQuery%'";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query, new { searchQuery = searchStr }).ToList();

                return result;
            }
        }

        public int GetAvailableSeats(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEvents")
                .WHERE("EventID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
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

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query.ToString(), new { id = eventId }).First();

                return result;
            }
        }

        public EventDate GetEventDateById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketEventDates")
                .WHERE("TicketEventDateID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query.ToString(), new { id }).First();

                return result;
            }
        }

        public List<EventDate> GetEventDates(int offset = 0, int maxLimit = 20)
        {
            var query = @"SELECT * FROM TicketEventDates
                        ORDER BY EventStartDateTime ASC
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";


            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<EventDate>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }

        public FullEventDate GetFullEventDateById(int id)
        {
            var query = @"SELECT * FROM TicketEventDates ted
                        JOIN TicketEvents te ON ted.TicketEventID = te.EventId
                        JOIN Venue v ON ted.VenueId = v.VenueID
                        WHERE ted.TicketEventDateID = @id";

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<FullEventDate>(query, new { id }).First();

                return result;
            }
        }

        public int GetSeats(int id)
        {
            return 0;
        }

        public EventDate UpdateEventDate(int id, int eventId, int venueId, DateTime dateTime)
        {
            var query = SQL
                .UPDATE("TicketEventDates")
                .SET("TicketEventID = @eventId, VenueId = @venueId, EventStartDateTime = @dateTime")
                .WHERE("TicketEventDateID = @id");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                connection.Execute(query, new { eventId, venueId, dateTime, id });
                var result = connection.Query<EventDate>("SELECT * FROM TicketEvents WHERE TicketEventId = @id", new { id }).First();

                return result;
            }
        }
    }
}
