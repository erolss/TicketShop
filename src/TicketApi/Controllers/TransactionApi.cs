/*
 * Ticket system api
 *
 * An API which gives access to all parts of the ticket system
 *
 * OpenAPI spec version: 1.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using TicketApi.Attributes;
using TicketApi.Models;
using TicketApi.Settings;
using TicketSystem.DbRepository;
using Microsoft.Extensions.Options;

namespace TicketApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class TransactionApiController : Controller
    {
        private DbSettings _dbSettings;
        private TransactionRepository _transactionRepository;

        public TransactionApiController(IOptions<DbSettings> db)
        {
            this._dbSettings = db.Value;
            this._transactionRepository = new TransactionRepository(_dbSettings.ConnectionString);
        }
        /// <summary>
        /// Create a transaction in the system
        /// </summary>
        /// <remarks>Creates a new transaction</remarks>
        /// <param name="body">transaction data for ticket purchase</param>
        /// <response code="200">Transaction created</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Route("/api/transaction")]
        [ValidateModelState]
        [SwaggerOperation("AddTransaction")]
        [SwaggerResponse(200, typeof(Object), "Transaction created")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult AddTransaction([FromBody]Transaction body)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete transaction
        /// </summary>
        /// <remarks>Deletes a single transaction</remarks>
        /// <param name="transactionId">ID of the transaction</param>
        /// <response code="200">Transaction deleted</response>
        /// <response code="404">Transaction not found</response>
        [HttpDelete]
        [Route("/api/transaction/{transactionId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteTransaction")]
        public virtual void DeleteTransaction([FromRoute]int? transactionId)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get transaction by Id
        /// </summary>
        /// <remarks>Returns a single transaction</remarks>
        /// <param name="transactionId">ID of the transaction</param>
        /// <response code="200">Transaction loaded</response>
        /// <response code="404">Transaction not found</response>
        [HttpGet]
        [Route("/api/transaction/{transactionId}")]
        [ValidateModelState]
        [SwaggerOperation("GetTransactionById")]
        [SwaggerResponse(200, typeof(Object), "Transaction loaded")]
        [SwaggerResponse(404, typeof(Object), "Transaction not found")]
        public virtual IActionResult GetTransactionById([FromRoute]int? transactionId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get all transactions in system
        /// </summary>
        /// <remarks>Returns all transactions</remarks>
        /// <response code="200">Transactions loaded</response>
        /// <response code="400">Bad request</response>
        [HttpGet]
        [Route("/api/transaction")]
        [ValidateModelState]
        [SwaggerOperation("GetTransactions")]
        [SwaggerResponse(200, typeof(List<Transaction>), "Transactions loaded")]
        [SwaggerResponse(400, typeof(List<Transaction>), "Bad request")]
        public virtual IActionResult GetTransactions()
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Transaction>>(exampleJson)
            : default(List<Transaction>);
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get transaction by Id
        /// </summary>
        /// <remarks>Returns a single transaction</remarks>
        /// <param name="transactionId">ID of the transaction</param>
        /// <param name="body">transaction data for ticket purchase</param>
        /// <response code="200">Transaction updated</response>
        /// <response code="404">Transaction not found</response>
        [HttpPut]
        [Route("/api/transaction/{transactionId}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateTransaction")]
        [SwaggerResponse(200, typeof(Object), "Transaction updated")]
        [SwaggerResponse(404, typeof(Object), "Transaction not found")]
        public virtual IActionResult UpdateTransaction([FromRoute]int? transactionId, [FromBody]Transaction body)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);
            return new ObjectResult(example);
        }
    }
}
