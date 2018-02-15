using Dapper;
using DbExtensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketApi.Db.Interface;
using TicketApi.Db.Model;

namespace TicketApi.Db
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Transaction AddTransaction(Transaction transaction)
        {
            var query = @"INSERT INTO TicketTransactions
                        VALUES(@transaction)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, transaction);
                var addedItemQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketTransactions') AS Current_Identity").First();
                var result = connection.Query<Transaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@id", new { id = addedItemQuery }).First();

                return result;
            }
        }

        public void DeleteTransactionById(int transactionId)
        {
            var query = SQL
                .DELETE_FROM("TicketTransactions")
                .WHERE("TransactionID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(query.ToString(), new { id = transactionId });
            }
        }

        public Transaction GetTransactionById(int transactionId)
        {
            var query = SQL
                 .SELECT("*")
                 .FROM("TicketTransactions")
                 .WHERE("TransactionID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Transaction>(query.ToString(), new { id = transactionId }).First();

                return result;
            }
        }

        public List<Transaction> GetTransactionByUserId(string userId)
        {
            var query = SQL
                .SELECT("*")
                .FROM("TicketTransactions")
                .WHERE("BuyerUserId = @userId");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Transaction>(query.ToString(), new { userId }).ToList();

                return result;
            }
        }

        public Transaction UpdateTransactionById(Transaction transaction)
        {
            var query = @"UPDATE TicketTransactions
                        SET @transaction";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, transaction);
                
                var result = connection.Query<Transaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@id", new { id = transaction.TransactionID }).First();

                return result;
               
            }
        }
    }
}
