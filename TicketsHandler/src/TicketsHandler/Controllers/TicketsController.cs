using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using TicketsHandler.Common.Extensions;
using TicketsHandler.Data.Commands;
using TicketsHandler.Data.Common;
using TicketsHandler.Data.DataTransfer;
using TicketsHandler.Data.Models;
using TicketsHandler.Data.Queries;

namespace TicketsHandler.Controllers
{
    [Route("tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        #region Queries

        /// <summary>Executes a query that returns a list of tickets.</summary>
        /// <param name="ticketsQueries"></param>
        /// <param name="pageNumber">Integer for page number.</param>
        /// <returns>A list of Tickets.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PayloadResponse<TicketDto>>> GetAllAsync([FromServices] ITicketsQueries ticketsQueries,
            [FromQuery] int pageNumber)
        {
            var result = await ticketsQueries.GetAllTickets(pageNumber);
            return result.IsSuccess
                ? (ActionResult<PayloadResponse<TicketDto>>)Ok(result) : Problem();
        }

        #endregion

        #region Actions

        /// <summary>Add Ticket.</summary>
        /// <param name="commandDispatcher"></param>
        /// <param name="addTicketCommand">Provides all of the information required to add Ticket.</param>
        /// <returns>Message indicating success or failure.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> AddTicketAsync([FromServices] ICommandDispatcher commandDispatcher, [FromBody] AddTicketCommand addTicketCommand)
        {
            var result = await commandDispatcher.Send(addTicketCommand);
            return this.FromResult(result);
        }


        /// <summary>Handle Ticket.</summary>
        /// <param name="commandDispatcher"></param> 
        /// <param name="id">Integer of Ticket.</param>
        /// <returns>Message indicating success or failure.</returns>
        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> HandleTicketAsync([FromServices] ICommandDispatcher commandDispatcher, [FromQuery] int id)
        {
            var result = await commandDispatcher.Send(new HandleTicketCommand(id));
            return this.FromResult(result);
        }

        
        /// <summary>Delete Ticket.</summary>
        /// <param name="commandDispatcher"></param> 
        /// <param name="id">Integer of Ticket.</param>
        /// <returns>Message indicating success or failure.</returns>
        [HttpDelete]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteTicketAsync([FromServices] ICommandDispatcher commandDispatcher, [FromQuery] int id)
        {
            var result = await commandDispatcher.Send(new DeleteTicketCommand(id));
            return this.FromResult(result);
        }
        #endregion
    }
}
