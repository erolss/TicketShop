using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.RestApiClient.Model;
using TicketShop.RestApiClient.Interface;
using RestSharp;

namespace TicketShop.RestApiClient
{
    public class VenueApi : IVenueApi
    {
        private readonly string _baseUrl;

        public VenueApi(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Venue AddVenue(Venue venue)
        {
            var outVar = venue.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/venue", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<Venue>(request);

            return response.Data;
        }

        public bool DeleteVenue(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/venue/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);

            var response = client.Execute<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Event with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<Venue> FindVenues(Search query)
        {
            var outVar = query.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/venue/search", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<List<Venue>>(request);

            return response.Data;
        }

        public Venue GetVenueById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<Venue>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<Venue> GetVenues(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<Venue>>(request);

            return response.Data;
        }

        public Venue UpdateVenue(Venue venue)
        {
            var outVar = venue.ToJson();
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event", Method.PUT);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);
            var response = client.Execute<Venue>(request);

            return response.Data;
        }
    }
}
