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
    public class TicketApiController : Controller
    {

        private DbSettings _dbSettings;
        private TicketRepository _ticketRepository;

        public TicketApiController(IOptions<DbSettings> db)
        {
            this._dbSettings = db.Value;
            this._ticketRepository = new TicketRepository(_dbSettings.ConnectionString);
        }
        /// <summary>
        /// Get a ticket by ID from the system
        /// </summary>
        /// <remarks>Returns a single ticket</remarks>
        /// <param name="ticketId">ID of the ticket</param>
        /// <response code="200">Ticket loaded</response>
        /// <response code="404">Ticket not found</response>
        [HttpGet]
        [Route("/api/ticket/{ticketId}")]
        [ValidateModelState]
        [SwaggerOperation("GetTicketById")]
        public virtual void GetTicketById([FromRoute]int? ticketId)
        { 
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <remarks>Returns all tickets</remarks>
        /// <response code="200">Ticket loaded</response>
        /// <response code="400">Bad request</response>
        [HttpGet]
        [Route("/api/ticket")]
        [ValidateModelState]
        [SwaggerOperation("GetTickets")]
        [SwaggerResponse(200, typeof(Ticket), "Ticket loaded")]
        [SwaggerResponse(400, typeof(Ticket), "Bad request")]
        public virtual IActionResult GetTickets()
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Ticket>(exampleJson)
            : default(Ticket);
            return new ObjectResult(example);
        }
    }
}
