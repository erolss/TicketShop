using Dapper;
using DbExtensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using TicketApi.Db.Interface;
using TicketApi.Db.Models;
using TicketApi.PaymentProvider;
using TicketApi.PaymentProvider.Model;

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

            var query = @"INSERT INTO TicketTransactions(BuyerLastName, BuyerFirstName, BuyerAddress, BuyerCity, BuyerEmail, BuyerUserId, TotalAmount)
                        VALUES(@BuyerLastName, @BuyerFirstName, @BuyerAddress, @BuyerCity, @BuyerEmail, @BuyerUserId, @TotalAmount)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Query(query, transaction);
                var addedItemQuery = connection.Query<int>("SELECT IDENT_CURRENT ('TicketTransactions') AS Current_Identity").First();
                //var result = connection.Query<Transaction>("SELECT * FROM TicketTransactions WHERE TransactionID=@id", new { id = addedItemQuery }).FirstOrDefault();

                var p = new PaymentProvider.PaymentProvider();
                var payment = p.Pay((decimal)transaction.TotalAmount, "SEK", addedItemQuery.ToString());
                transaction.TransactionID = addedItemQuery;
                transaction.PaymentReferenceId = payment.PaymentReference;
                transaction.PaymentStatus = payment.PaymentStatus.ToString();

                var result = UpdateTransaction(transaction);

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
                        SET BuyerLastName = @BuyerLastName,
                        BuyerFirstName = @BuyerFirstName,
                        BuyerAddress = @BuyerAddress,
                        BuyerCity = @BuyerCity,
                        BuyerEmail = @BuyerEmail,
                        BuyerUserId = @BuyerUserId,
                        TotalAmount = @TotalAmount,
                        PaymentReferenceId = @PaymentReferenceId,
                        PaymentStatus = @PaymentStatus
                        WHERE TransactionID = @TransactionID";

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

            var query = string.Format(@"SELECT * FROM TicketTransactions
                        WHERE
                            BuyerLastName like '%{0}%' OR
                            BuyerFirstName like '%{0}%' OR
                            BuyerAddress like '%{0}%' OR
                            BuyerCity like '%{0}%' OR
                            BuyerEmail like '%{0}%' OR
                            BuyerUserId like '%{0}%' OR
                            PaymentReference like '%{0}%' OR
                            PaymentStatus like '%{0}%' OR
                            TotalAmount like '%{0}%'", searchStr);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Transaction>(query, new { s = searchStr }).ToList();

                return result;
            }
        }

        public List<Transaction> GetTransactions(int offset = 0, int maxLimit = 20)
        {
            if (maxLimit > 30)
            {
                maxLimit = 30;
            }

            var query = @"SELECT * FROM TicketTransactions
                        ORDER BY TransactionID
                        OFFSET @offset ROWS
                        FETCH NEXT @maxLimit ROWS ONLY";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = connection.Query<Transaction>(query, new { offset, maxLimit }).ToList();
                return result;
            }
        }
    }
}
