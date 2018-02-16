using System;
using System.Collections.Generic;
using System.Text;
using TicketApi.Db.Models;

namespace TicketApi.Db.Interface
{
    public interface ITransactionRepository
    {
        /// <summary>
        /// Get transactions from db
        /// </summary>
        /// <param name="offset">result set offset</param>
        /// <param name="maxLimit">Max rows to fetch</param>
        /// <returns>A list of object representations of Transactions</returns>
        List<Transaction> GetTransactions(int offset = 0, int maxLimit = 20);
        /// <summary>
        /// Get Transaction by Id
        /// </summary>
        /// <param name="transactionId">ID of Transaction</param>
        /// <returns>An object representation of the Transaction</returns>
        Transaction GetTransactionById(int transactionId);

        /// <summary>
        /// Add new Transaction
        /// </summary>
        /// <param name="transaction">An object representation of the Transaction to create in Database</param>
        /// <returns>An object representation of the created Transaction</returns>
        Transaction AddTransaction(Transaction transaction);

        /// <summary>
        /// Update a transaction by Id
        /// </summary>
        /// <param name="transaction">Transaction Object</param>
        /// <returns>An object representation of the updated Transaction</returns>
        Transaction UpdateTransaction(Transaction transaction);
        /// <summary>
        /// Delete a transaction
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        bool DeleteTransactionById(int transactionId);

        /// <summary>
        /// Get Transactions by User Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>A list of object representations of the Transactions</returns>
        List<Transaction> GetTransactionByUserId(string userId);

        /// <summary>
        /// Find transactions matching the query
        /// </summary>
        /// <param name="searchStr">Search query</param>
        /// <returns>A list of object representations of Transactions</returns>
        List<Transaction> FindTransactions(string searchStr);

    }
}
