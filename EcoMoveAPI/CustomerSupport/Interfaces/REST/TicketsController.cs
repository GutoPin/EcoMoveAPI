using System.Net.Mime;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;
using EcoMoveAPI.CustomerSupport.Domain.Services;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TicketsController(
    ITicketCommandService ticketCommandService,
    ITicketQueryService ticketQueryService
    ) : ControllerBase
{
    /**
     * Create Ticket.
     * <summary>
     *     This method is responsible for handling the request to create a new ticket.
     * </summary>
     * <param name="createTicketResource">The resource containing the information to create a new ticket.</param>
     * <returns>The newly created ticket resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a ticket",
        Description = "Creates a ticket with a given title and description",
        OperationId = "CreateTicket")]
    [SwaggerResponse(201, "The ticket was created", typeof(TicketResource))]
    public async Task<IActionResult> CreateTicket([FromBody] CreateTicketResource createTicketResource)
    {
        var createTicketCommand =
            CreateTicketCommandFromResourceAssembler.ToCommandFromResource(createTicketResource);
        var ticket = await ticketCommandService.Handle(createTicketCommand);
        if (ticket is null) return BadRequest();
        var resource = TicketResourceFromEntityAssembler.ToResourceFromEntity(ticket);
        return CreatedAtAction(nameof(GetTicketById), new { ticketId = resource.Id }, resource);
    }
    
    /**
     * Get Ticket By Id.
     * <summary>
     *     This method is responsible for handling the request to get a ticket by its id.
     * </summary>
     * <param name="ticketId">The ticket identifier.</param>
     * <returns>The ticket resource.</returns>
     */
    [HttpGet("{ticketId:int}")]
    [SwaggerOperation(
        Summary = "Gets a ticket by id",
        Description = "Gets a ticket for a given identifier",
        OperationId = "GetTicketById")]
    [SwaggerResponse(200, "The ticket was found", typeof(TicketResource))]
    public async Task<IActionResult> GetTicketById(int ticketId)
    {
        var getTicketByIdQuery = new GetTicketByTicketIdQuery(ticketId);
        var ticket = await ticketQueryService.Handle(getTicketByIdQuery);
        if (ticket == null) return NotFound();
        var resource = TicketResourceFromEntityAssembler.ToResourceFromEntity(ticket);
        return Ok(resource);
    }
    
    /**
     * Get Tickets By User Id.
     * <summary>
     *     This method is responsible for handling the request to get all tickets by user id.
     * </summary>
     * <param name="userId">The user identifier.</param>
     * <returns>The ticket resources.</returns>
     */
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets tickets by user id",
        Description = "Gets all tickets for a given user identifier",
        OperationId = "GetTicketsByUserId")]
    [SwaggerResponse(200, "The tickets were found", typeof(IEnumerable<TicketResource>))]
    public async Task<IActionResult> GetTicketsByUserId(int userId)
    {
        var getTicketsByUserIdQuery = new GetAllTicketsByUserIdQuery(userId);
        var tickets = await ticketQueryService.Handle(getTicketsByUserIdQuery);
        var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /**
     * Get Tickets By Customer Support Agent Id.
     * <summary>
     *     This method is responsible for handling the request to get all tickets by customer support agent id.
     * </summary>
     * <param name="customerSupportAgentId">The customer support agent identifier.</param>
     * <returns>The ticket resources.</returns>
     */
    [HttpGet("agent/{customerSupportAgentId:int}")]
    [SwaggerOperation(
        Summary = "Gets tickets by customer support agent id",
        Description = "Gets all tickets for a given customer support agent identifier",
        OperationId = "GetTicketsByCustomerSupportAgentId")]
    [SwaggerResponse(200, "The tickets were found", typeof(IEnumerable<TicketResource>))]
    public async Task<IActionResult> GetTicketsByCustomerSupportAgentId(int customerSupportAgentId)
    {
        var getTicketsByCustomerSupportAgentIdQuery = new GetAllTicketsByCustomerSupportAgentIdQuery(customerSupportAgentId);
        var tickets = await ticketQueryService.Handle(getTicketsByCustomerSupportAgentIdQuery);
        var resources = tickets.Select(TicketResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
}