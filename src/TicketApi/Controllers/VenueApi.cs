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
using Microsoft.Extensions.Options;
using TicketApi.Db;
using TicketApi.Settings;

namespace TicketApi.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class VenueApiController : Controller
    {

        private CustomSettings _dbSettings;
        private VenueRepository _venueRepository;

        public VenueApiController(IOptions<CustomSettings> db)
        {
            this._dbSettings = db.Value;
            this._venueRepository = new VenueRepository(_dbSettings.DefaultConnection);
        }

        /// <summary>
        /// Add Venue
        /// </summary>
        /// <remarks>Add new venue to system</remarks>
        /// <param name="venue">Venue object</param>
        /// <response code="200">Venue added</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Route("/api/venue")]
        [ValidateModelState]
        [SwaggerOperation("AddVenue")]
        [SwaggerResponse(200, typeof(Object), "Venue added")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult AddVenue([FromBody]Venue venue)
        {
            var result = _venueRepository.AddVenue(venue);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Delete venue
        /// </summary>
        /// <remarks>Delete a venue</remarks>
        /// <param name="venue">Venue object</param>
        /// <response code="200">Venue deleted</response>
        /// <response code="404">Bad request</response>
        [HttpDelete]
        [Route("/api/venue")]
        [ValidateModelState]
        [SwaggerOperation("DeleteVenue")]
        [SwaggerResponse(200, typeof(Object), "Venue deleted")]
        [SwaggerResponse(404, typeof(Object), "Venue not found")]
        public virtual IActionResult DeleteVenue([FromBody]Venue venue)
        {
            var result = _venueRepository.DeleteVenue((int)venue.VenueID);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        /// Get all venues matching query
        /// </summary>
        /// <remarks>Returns a list of venues matching the query</remarks>
        /// <param name="query">venue search string object type Search</param>
        /// <response code="200">Venue search results loaded</response>
        /// <response code="404">No venues found</response>
        [HttpPost]
        [Route("/api/venue/search")]
        [ValidateModelState]
        [SwaggerOperation("FindVenues")]
        [SwaggerResponse(200, typeof(List<Venue>), "Venue search results loaded")]
        [SwaggerResponse(404, typeof(List<Venue>), "No venues found")]
        public virtual IActionResult FindVenues([FromBody]Search query)
        {
            var result = _venueRepository.FindVenues(query.Searchstring);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get venue by Id
        /// </summary>
        /// <remarks>Returns venue by ID</remarks>
        /// <param name="venueId">Venue ID</param>
        /// <response code="200">Venues loaded</response>
        /// <response code="404">Venue not found</response>
        [HttpGet]
        [Route("/api/venue/{venueId}")]
        [ValidateModelState]
        [SwaggerOperation("GetVenueById")]
        [SwaggerResponse(200, typeof(Object), "Venue loaded")]
        [SwaggerResponse(404, typeof(Object), "Venue not found")]
        public virtual IActionResult GetVenueById([FromRoute]int? venueId)
        {
            var result = _venueRepository.GetVenueById((int)venueId);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get all venues
        /// </summary>
        /// <remarks>Returns all venues</remarks>
        /// <response code="200">Venues loaded</response>
        /// <response code="400">Bad request</response>
        [HttpGet]
        [Route("/api/venue")]
        [Route("/api/venue/{offset}/{maxLimit}")]        
        [ValidateModelState]
        [SwaggerOperation("GetVenues")]
        [SwaggerResponse(200, typeof(List<Venue>), "Venues loaded")]
        [SwaggerResponse(400, typeof(List<Venue>), "Bad request")]
        public virtual IActionResult GetVenues([FromRoute]int offset=0, [FromRoute]int maxLimit=20)
        {
            var result = _venueRepository.GetVenues(offset, maxLimit);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }

        /// <summary>
        /// Update venue
        /// </summary>
        /// <remarks>Update a venue in the system</remarks>
        /// <param name="venue">Venue object</param>
        /// <response code="200">Venue updated</response>
        /// <response code="400">Bad request</response>
        [HttpPut]
        [Route("/api/venue")]
        [ValidateModelState]
        [SwaggerOperation("UpdateVenue")]
        [SwaggerResponse(200, typeof(Object), "Venue updated")]
        [SwaggerResponse(400, typeof(Object), "Bad request")]
        public virtual IActionResult UpdateVenue([FromBody]Venue venue)
        {
            var result = _venueRepository.UpdateVenue(venue);
            if (result == null)
            {
                return BadRequest();
            }
            return new ObjectResult(result);
        }
    }
}
