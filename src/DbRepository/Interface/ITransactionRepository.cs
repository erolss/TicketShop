using System;
using System.Collections.Generic;
using System.Text;
using TicketSystem.DbRepository.Model;

namespace TicketSystem.DbRepository.Interface
{
    public interface ITransactionRepository
    {
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
        /// <param name="transactionId">Transaction Id</param>
        /// <returns>An object representation of the updated Transaction</returns>
        Transaction UpdateTransactionById(Transaction transaction);
        /// <summary>
        /// Delete a transaction
        /// </summary>
        /// <param name="transactionId">Transaction Id</param>
        void DeleteTransactionById(int transactionId);

        /// <summary>
        /// Get Transactions by User Id
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>A list of object representations of the Transactions</returns>
        List<Transaction> GetTransactionByUserId(string userId);

    }
}
