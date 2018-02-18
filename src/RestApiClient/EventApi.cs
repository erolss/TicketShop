using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.RestApiClient.Interface;
using TicketShop.RestApiClient.Model;

namespace TicketShop.RestApiClient
{
    public class EventApi : IEventApi
    {
        private readonly string _baseUrl;

        public EventApi(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public Event AddEvent(Event item)
        {
            var outVar = item.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<Event>(request);

            return response.Data;
        }

        public bool DeleteEvent(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);

            var response = client.Execute<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Event with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<Event> FindEvents(Search query)
        {
            var outVar = query.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/search", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<List<Event>>(request);

            return response.Data;
        }

        public Event GetEventById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<Event>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<Event> GetEvents(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<Event>>(request);

            return response.Data;
        }

        public Event UpdateEvent(Event item)
        {
            var outVar = item.ToJson();
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event", Method.PUT);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);
            var response = client.Execute<Event>(request);

            return response.Data;
        }
    }
}
