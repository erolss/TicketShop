using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketSystem.RestApiClient.Interface;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        private readonly string _baseUrl;

        public TicketApi(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }
        public Ticket AddTicket(Ticket ticket)
        {
            var outVar = ticket.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/event", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<Ticket>(request);

            return response.Data;
        }

        public bool DeleteTicket(int ticketId)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket/{id}", Method.DELETE);
            request.AddUrlSegment("id", ticketId);

            var response = client.Execute<bool>(request);

            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(String.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;

        }

        public FullTicket GetFullTicketById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket/full/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<FullTicket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("FullTicket with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<FullTicket> GetFullTicketsByTransactionId(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket/{id}", Method.GET);

            request.AddUrlSegment("id", id);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", id));
            }

            return response.Data;
        }

        public List<Ticket> GetTickets(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<Ticket>>(request);

            return response.Data;
        }

        public List<Ticket> GetTicketsByTransactionId(int transactionId, int offset = 0, int maxLimit = 20)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByUserId(string userId, int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket/userid/{userId}/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("userId", userId);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);
            
            var response = client.Execute<List<Ticket>>(request);

            return response.Data;
        }

       

        public Ticket UpdateTicket(Ticket ticket)
        {
            var outVar = ticket.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/ticket", Method.PUT);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);
            var response = client.Execute<Ticket>(request);

            return response.Data;
        }
    }
}
