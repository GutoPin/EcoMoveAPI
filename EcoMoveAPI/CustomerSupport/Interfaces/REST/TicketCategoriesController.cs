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
public class TicketCategoriesController(
    ITicketCategoryCommandService ticketCategoryCommandService,
    ITicketCategoryQueryService ticketCategoryQueryService
    ) : ControllerBase
{
    /**
     * Create Ticket Category.
     * <summary>
     *     This method is responsible for handling the request to create a new ticket category.
     * </summary>
     * <param name="createTicketCategoryResource">The resource containing the information to create a new ticket category.</param>
     * <returns>The newly created ticket category resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a ticket category",
        Description = "Creates a ticket category with a given name",
        OperationId = "CreateCategory")]
    [SwaggerResponse(201, "The ticket category was created", typeof(TicketCategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateTicketCategoryResource createTicketCategoryResource)
    {
        var createTicketCategoryCommand =
            CreateTicketCategoryCommandFromResourceAssembler.ToCommandFromResource(createTicketCategoryResource);
        var ticketCategory = await ticketCategoryCommandService.Handle(createTicketCategoryCommand);
        if (ticketCategory is null) return BadRequest();
        var resource = TicketCategoryResourceFromEntityAssembler.ToResourceFromEntity(ticketCategory);
        return CreatedAtAction(nameof(GetCategoryById), new { categoryId = resource.Id }, resource);
    }
    
    /**
     * Get Category By Id.
     * <summary>
     *     This method is responsible for handling the request to get a category by its id.
     * </summary>
     * <param name="categoryId">The category identifier.</param>
     * <returns>The category resource.</returns>
     */
    [HttpGet("{categoryId:int}")]
    [SwaggerOperation(
        Summary = "Gets a category by id",
        Description = "Gets a category for a given identifier",
        OperationId = "GetCategoryById")]
    [SwaggerResponse(200, "The category was found", typeof(TicketCategoryResource))]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetTicketCategoryByTicketCategoryIdQuery(categoryId);
        var category = await ticketCategoryQueryService.Handle(getCategoryByIdQuery);
        var resource = TicketCategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
}