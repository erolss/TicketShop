using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TicketShop.RestApiClient.Interface;
using TicketShop.RestApiClient.Model;

namespace TicketShop.RestApiClient
{
    public class EventDateApi : IEventDateApi
    {
        private string _baseUrl;

        public EventDateApi(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }
        public EventDate AddEventDate(EventDate eventDate)
        {
            var outVar = eventDate.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<EventDate>(request);

            return response.Data;
        }

        public bool DeleteEventDate(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/{id}", Method.DELETE);
            request.AddUrlSegment("id", id);

            var response = client.Execute<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("EventDate with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<EventDate> FindEventDates(Search query)
        {
            var outVar = query.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event/search", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<List<EventDate>>(request);

            return response.Data;
        }
        public List<FullEventDate> FindFullEventDates(Search query)
        {
            var outVar = query.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/search", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<List<FullEventDate>>(request);

            return response.Data;
        }

        public EventDate GetEventDateByEventId(int eventId)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/{id}", Method.GET);

            request.AddUrlSegment("id", eventId);
            var response = client.Execute<EventDate>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("EventDate with EventID: {0} is not found", eventId));
            }

            return response.Data;
        }

        public EventDate GetEventDateById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<EventDate>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("EventDate with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<EventDate> GetEventDates(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<EventDate>>(request);

            return response.Data;
        }

        public List<FullEventDate> GetFullEventDates(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/full/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<FullEventDate>>(request);

            return response.Data;
        }

        public List<FullEventDate> GetFullEventDatesByEventId(int eventId, int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/eventId/{eventId}/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("eventId", eventId);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<FullEventDate>>(request);

            return response.Data;
        }

        public FullEventDate GetFullEventDateById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/full/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<FullEventDate>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("EventDate with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public int GetSoldTicketCount(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/eventdate/soldtickets/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<int>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("EventDate with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public EventDate UpdateEventDate(EventDate eventDate)
        {
            var outVar = eventDate.ToJson();
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event", Method.PUT);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);
            var response = client.Execute<EventDate>(request);

            return response.Data;
        }
    }
}
