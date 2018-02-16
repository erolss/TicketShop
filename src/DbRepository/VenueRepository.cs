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
    public class VenueRepository : IVenueRepository
    {
        private readonly string _connectionString;

        public VenueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Venue AddVenue(Venue venue)
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var query = @"INSERT INTO Venues([VenueName], [Address], [City], [Country])
                            VALUES(@name, @address, @city, @country)";

                var values = new {
                    name = venue.VenueName,
                    address = venue.Address,
                    city = venue.City,
                    country = venue.Country
                };

                connection.Open();
                connection.Query(query, values);
                var addedItemQuery = connection.Query<int>("SELECT IDENT_CURRENT ('Venues') AS Current_Identity").First();
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID=@Id", new { Id = addedItemQuery }).FirstOrDefault();
            }
        }

        public bool DeleteVenue(int id)
        {
            var query = SQL
                .DELETE_FROM("Venues")
                .WHERE("VenueID = @id");
            
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

        public Venue GetVenueById(int id)
        {
            var query = SQL
                .SELECT("*")
                .FROM("Venues")
                .WHERE("VenueID = @id");
            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Venue>(query.ToString(), new { id }).FirstOrDefault();

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

            
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Venue>(query, new { offset, maxLimit }).ToList();

                return result;
            }
        }

        public Venue UpdateVenue(Venue venue)
        {
            var query = SQL
                .UPDATE("Venues")
                .SET("VenueName = @name, Address = @address, City = @city, Country = @country")
                .WHERE("VenueID = @id");
            var values = new
            {
                id = venue.VenueID,
                name = venue.VenueName,
                address = venue.Address,
                city = venue.City,
                country = venue.Country
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), values);
                return connection.Query<Venue>("SELECT * FROM Venues WHERE VenueID = @id", new { values.id }).FirstOrDefault();
            }
        }

        public List<Venue> FindVenues(string searchStr)
        {
           var query = String.Format(@"SELECT * FROM Venues 
                        WHERE
                        VenueName LIKE '%{0}%' OR 
                        Address LIKE '%{0}%' OR 
                        City LIKE '%{0}%' OR 
                        Country LIKE '%{0}%'",searchStr);



            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                
                var result = connection.Query<Venue>(query).ToList();

                return result;
            }
        }



    }
}
