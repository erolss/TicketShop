using RestSharp;
using System;
using System.Collections.Generic;
using TicketSystem.RestApiClient.Model;
using TicketSystem.RestApiClient.Interface;

namespace TicketSystem.RestApiClient
{
    public class TicketApi : ITicketApi
    {
        public Ticket AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public FullTicket GetFullTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public List<FullTicket> GetFullTicketsByTransactionId(int transactionId)
        {
            throw new NotImplementedException();
        }

        public Ticket GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTickets(int offset = 0, int maxLimit = 20)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByTransactionId(int transactionId, int offset = 0, int maxLimit = 20)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> GetTicketsByUserId(string userId, int offset = 0, int maxLimit = 20)
        {
            throw new NotImplementedException();
        }

        // Implemented using RestSharp: http://restsharp.org/

        public List<Ticket> TicketGet()
        {
            var client = new RestClient("http://localhost:18001/");
            var request = new RestRequest("ticket", Method.GET);
            var response = client.Execute<List<Ticket>>(request);
            return response.Data;
        }

        public Ticket TicketTicketIdGet(int ticketId)
        {
            var client = new RestClient("http://localhost:18001/");
            var request = new RestRequest("ticket/{id}", Method.GET);
            
            request.AddUrlSegment("id", ticketId);
            var response = client.Execute<Ticket>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Ticket with ID: {0} is not found", ticketId));
            }

            return response.Data;
        }

        public Ticket UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
