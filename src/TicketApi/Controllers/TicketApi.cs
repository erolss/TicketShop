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
using TicketApi.Db.Models;
using TicketApi.Settings;
using TicketApi.Db;
using Microsoft.Extensions.Options;

namespace TicketApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class TicketApiController : Controller
    {

        private CustomSettings _dbSettings;
        private TicketRepository _ticketRepository;

        public TicketApiController(IOptions<CustomSettings> db)
        {
            this._dbSettings = db.Value;
            this._ticketRepository = new TicketRepository(_dbSettings.DefaultConnection);
        }

        /// <summary>
        /// Add new ticket
        /// </summary>
        /// <remarks>Adds a new ticket in system</remarks>
        /// <param name="ticket">Ticket data</param>
        /// <response code="200">Ticket created</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Route("/api/ticket")]
        [ValidateModelState]
        [SwaggerOperation("AddTicket")]
        [SwaggerResponse(200, typeof(Object), "Ticket created")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult AddTicket([FromBody]Ticket ticket)
        {
            var result = _ticketRepository.AddTicket(ticket);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }
        /// <summary>
        /// Add a ticket and connect transaction in system
        /// </summary>
        /// <param name="ticket">ticket object</param>
        /// <returns>A ticket object</returns>
        [HttpPost]
        [Route("/api/ticketorder")]
        [ValidateModelState]
        [SwaggerOperation("AddTicketOrder")]
        [SwaggerResponse(200, typeof(Object), "Ticket created")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult AddTicketOrder([FromBody]Ticket ticket)
        {
            var result = _ticketRepository.AddTicketOrder(ticket);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Delete ticket
        /// </summary>
        /// <remarks>Delete a ticket in system</remarks>
        /// <param name="ticket">Ticket data</param>
        /// <response code="200">Ticket deleted</response>
        /// <response code="400">Bad request</response>
        [HttpDelete]
        [Route("/api/ticket")]
        [ValidateModelState]
        [SwaggerOperation("DeleteTicket")]
        [SwaggerResponse(200, typeof(Object), "Ticket deleted")]
        [SwaggerResponse(404, typeof(Object), "Ticket not found")]
        public virtual IActionResult DeleteTicket([FromBody]Ticket ticket)
        {
            var result = _ticketRepository.DeleteTicket((int)ticket.TicketID);
            if (result)
            {
                return Ok();
            }
            return NotFound();
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
        [SwaggerResponse(200, typeof(Object), "Ticket loaded")]
        [SwaggerResponse(404, typeof(Object), "Ticket not found")]
        public virtual IActionResult GetTicketById([FromRoute]int? ticketId)
        {
            var result = _ticketRepository.GetTicketById((int)ticketId);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get all tickets
        /// </summary>
        /// <remarks>Returns all tickets</remarks>
        /// <response code="200">Ticket loaded</response>
        /// <response code="400">Bad request</response>
        [HttpGet]
        [Route("/api/ticket")]
        [Route("/api/ticket/{offset}/{maxLimit}")]
        [ValidateModelState]
        [SwaggerOperation("GetTickets")]
        [SwaggerResponse(200, typeof(List<Ticket>), "Ticket loaded")]
        [SwaggerResponse(400, typeof(List<Ticket>), "Bad request")]
        public virtual IActionResult GetTickets([FromRoute]int offset = 0, [FromRoute]int maxLimit = 20)
        {
            var result = _ticketRepository.GetTickets(offset, maxLimit);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get tickets by User Id
        /// </summary>
        /// <remarks>Returns a list of tickets</remarks>
        /// <param name="userId">userId of the ticket</param>
        /// <param name="offset">result set offset</param>
        /// <param name="maxLimit">max results to fetch</param>
        /// <response code="200">Ticket loaded</response>
        /// <response code="404">Ticket not found</response>
        [HttpGet]
        [Route("/api/ticket/userid/{userId}/{offset}/{maxLimit}")]
        [ValidateModelState]
        [SwaggerOperation("GetTicketsByUserId")]
        [SwaggerResponse(200, typeof(List<Ticket>), "Ticket loaded")]
        [SwaggerResponse(404, typeof(List<Ticket>), "Ticket not found")]
        public virtual IActionResult GetTicketsByUserId([FromRoute]string userId, [FromRoute]int offset=0, [FromRoute]int maxLimit=20)
        {
            var result = _ticketRepository.GetTicketsByUserId(userId, offset, maxLimit);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Update ticket
        /// </summary>
        /// <remarks>Update a ticket in system</remarks>
        /// <param name="ticket">Ticket data</param>
        /// <response code="200">Ticket updated</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        [Route("/api/ticket")]
        [ValidateModelState]
        [SwaggerOperation("UpdateTicket")]
        [SwaggerResponse(200, typeof(Object), "Ticket updated")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult UpdateTicket([FromBody]Ticket ticket)
        {
            var result = _ticketRepository.UpdateTicket(ticket);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get FullTicket by Id in system
        /// </summary>
        /// <remarks>Returns an FullTicket by ID</remarks>
        /// <param name="ticketId">TicketID</param>
        /// <response code="200">Ticket loaded</response>
        /// <response code="404">Ticket not found</response>
        [HttpGet]
        [Route("/api/ticket/full/{ticketId}")]
        [ValidateModelState]
        [SwaggerOperation("GetFullTicketById")]
        [SwaggerResponse(200, typeof(Object), "Ticket loaded")]
        [SwaggerResponse(404, typeof(Object), "Ticket not found")]
        public virtual IActionResult GetFullTicketById([FromRoute]int? ticketId)
        {
            var result = _ticketRepository.GetFullTicketById((int)ticketId);
            if (result == null)
            {
                return NotFound();
            }
            return new ObjectResult(result);
        }

    }
}
