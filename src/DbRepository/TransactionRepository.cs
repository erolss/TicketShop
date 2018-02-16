using Dapper;
using DbExtensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketApi.Db.Interface;
using TicketApi.Db.Models;

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
                var result = connection.Query<Transaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@id", new { id = addedItemQuery }).FirstOrDefault();

                return result;
            }
        }

        public bool DeleteTransactionById(int transactionId)
        {
            var query = SQL
                .DELETE_FROM("TicketTransactions")
                .WHERE("TransactionID = @id");

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if (connection.Execute(query.ToString(), new { id = transactionId }) > 0)
                {
                    return true;
                }
            }
            return false;
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
                var result = connection.Query<Transaction>(query.ToString(), new { id = transactionId }).FirstOrDefault();

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

        public Transaction UpdateTransaction(Transaction transaction)
        {
            var query = @"UPDATE TicketTransactions
                        SET @transaction";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, transaction);

                var result = connection.Query<Transaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@id", new { id = transaction.TransactionID }).FirstOrDefault();

                return result;

            }
        }

        public List<Transaction> FindTransactions(string searchStr)
        {
            
            var query = @"SELECT * FROM Transactions
                        WHERE
                            BuyerLastName like '%@s%' OR
                            BuyerFirstName like '%@s%' OR
                            BuyerAddress like '%@s%' OR
                            BuyerCity like '%@s%' OR
                            BuyerEmail like '%@s%' OR
                            BuyerUserId like '%@s%' OR
                            PaymentReference like '%@s%' OR
                            PaymentStatus like '%@s%' OR
                            TotalAmount like '%@s%'";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Transaction>(query, new { s = searchStr }).ToList();

                return result;
            }
        }


    }
}
