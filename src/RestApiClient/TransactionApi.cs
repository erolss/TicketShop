using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.RestApiClient.Model;
using TicketSystem.RestApiClient.Interface;
using RestSharp;

namespace TicketSystem.RestApiClient
{
    public class TransactionApi : ITransactionApi
    {
        private readonly string _baseUrl;

        public TransactionApi(string baseUrl)
        {
            this._baseUrl = baseUrl;
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            var outVar = transaction.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<Transaction>(request);

            return response.Data;
        }

        public bool DeleteTransactionById(int transactionId)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction/{id}", Method.DELETE);
            request.AddUrlSegment("id", transactionId);

            var response = client.Execute<bool>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(String.Format("Ticket with ID: {0} is not found", transactionId));
            }

            return response.Data;
        }

        public List<Transaction> FindTransactions(Search query)
        {
            var outVar = query.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction/search", Method.POST);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);

            var response = client.Execute<List<Transaction>>(request);

            return response.Data;
        }

        public Transaction GetTransactionById(int transactionId)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction/{id}", Method.GET);

            request.AddUrlSegment("id", transactionId);
            var response = client.Execute<Transaction>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new KeyNotFoundException(string.Format("Transaction with ID: {0} is not found", transactionId));
            }

            return response.Data;
        }

        //public List<Transaction> GetTransactionByUserId(string userId)
        //{
        //    var client = new RestClient(_baseUrl);
        //    var request = new RestRequest("api/transaction/userid/{id}", Method.GET);

        //    request.AddUrlSegment("id", transactionId);
        //    var response = client.Execute<Transaction>(request);

        //    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        throw new KeyNotFoundException(string.Format("Transaction with ID: {0} is not found", transactionId));
        //    }

        //    return response.Data;
        //}

        public List<Transaction> GetTransactions(int offset = 0, int maxLimit = 20)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction/{offset}/{maxLimit}", Method.GET);
            request.AddUrlSegment("offset", offset);
            request.AddUrlSegment("maxLimit", maxLimit);

            var response = client.Execute<List<Transaction>>(request);

            return response.Data;
        }

        public Transaction UpdateTransaction(Transaction transaction)
        {
            var outVar = transaction.ToJson();

            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/transaction", Method.PUT);
            request.AddParameter("application/json", outVar, ParameterType.RequestBody);
            var response = client.Execute<Transaction>(request);

            return response.Data;
        }
    }
}
