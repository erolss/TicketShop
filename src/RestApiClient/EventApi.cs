using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.RestApiClient.Interface;
using TicketSystem.RestApiClient.Model;

namespace TicketSystem.RestApiClient
{
    public class EventApi : IEventApi
    {
        public Event AddEvent(Event item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> FindEvents(string searchStr)
        {
            throw new NotImplementedException();
        }

        public Event GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetEvents(int offset = 0, int maxLimit = 20)
        {
            throw new NotImplementedException();
        }

        public Event UpdateEvent(Event item)
        {
            var output = item.ToJson();
            var client = new RestClient("localhost");
            var request = new RestRequest("api/event", Method.PUT);
            request.AddParameter("application/json", item, ParameterType.RequestBody);
            var response = client.Execute<Event>(request);

            return (Event)response;
        }
    }
}
