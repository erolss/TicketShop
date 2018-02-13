using Dapper;
using DbExtensions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketSystem.DatabaseRepository.Interface;
using TicketSystem.DatabaseRepository.Model;


namespace TicketSystem.DatabaseRepository
{
    class VenueRepository : IVenueRepository
    {
        public Venue AddVenue(string name, string address, string city, string country)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query("insert into Venues([VenueName],[Address],[City],[Country]) values(@Name,@Address, @City, @Country)", new { Name = name, Address = address, City = city, Country = country });
                var addedVenueQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedVenueQuery }).First();
            }
        }

        public void DeleteVenue(int id)
        {
            var query = SQL
                .DELETE_FROM("Venues")
                .WHERE("VenueID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { id });
            }
        }

        public Venue GetVenueById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("Venues")
                .WHERE("VenueID = @id");

            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Venue>(query.ToString(), new { id }).First();

                return result;
            }
        }

        public List<Venue> GetVenues(int offset = 0, int maxLimit = 20)
        {
            //var query = SQL
            //    .SELECT("*")
            //    .FROM("Venues")
            //    .OFFSET("@offset")
            //    .LIMIT("@limit")
            //    .WHERE("VenueId = @id");
            var query = @"SELECT * FROM Venues
                        ORDER BY VenueID
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";


            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Venue>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }

        public Venue UpdateVenue(int id, string name, string address, string city, string country)
        {
            var query = SQL
                .UPDATE("Venues")
                .SET("VenueName = @name, Address = @address, City = @city, Country = @country")
                .WHERE("VenueID = @id");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { id, name, address, city, country });
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID = @id", new { id }).First();
            }
        }

        public List<Venue> FindVenue(string searchStr)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TicketSystem"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Query<Venue>("SELECT * FROM Venues WHERE VenueName like '%" + searchStr + "%' OR Address like '%" + searchStr + "%' OR City like '%" + searchStr + "%' OR Country like '%" + searchStr + "%'").ToList();

                return result;
            }
        }



    }
}
