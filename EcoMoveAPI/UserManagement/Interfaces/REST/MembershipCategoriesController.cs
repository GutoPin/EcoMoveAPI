using System.Net.Mime;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Services;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;
using EcoMoveAPI.UserManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.UserManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MembershipCategoriesController(
    IMembershipCategoryCommandService membershipCategoryCommandService,
    IMembershipCategoryQueryService membershipCategoryQueryService
    ): ControllerBase
{
    /**
     * Create Membership Category.
     * <summary>
     *     This method is responsible for handling the request to create a new membership category.
     * </summary>
     * <param name="createMembershipCategoryResource">The resource containing the information to create a new membership category.</param>
     * <returns>The newly created membership category resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a ticket category",
        Description = "Creates a ticket category with a given name",
        OperationId = "CreateCategory")]
    [SwaggerResponse(201, "The ticket category was created", typeof(MembershipCategoryResource))]
    public async Task<IActionResult> CreateCategory([FromBody] CreateMembershipCategoryResource createMembershipCategoryResource)
    {
        var createTicketCategoryCommand =
            CreateMembershipCategoryCommandFromResourceAssembler.ToCommandFromResource(createMembershipCategoryResource);
        var ticketCategory = await membershipCategoryCommandService.Handle(createTicketCategoryCommand);
        if (ticketCategory is null) return BadRequest();
        var resource = MembershipCategoryResourceFromEntityAssembler.ToResourceFromEntity(ticketCategory);
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
    [SwaggerResponse(200, "The category was found", typeof(MembershipCategoryResource))]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var getCategoryByIdQuery = new GetMembershipCategoryByMembershipCategoryIdQuery(categoryId);
        var category = await membershipCategoryQueryService.Handle(getCategoryByIdQuery);
        var resource = MembershipCategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
        return Ok(resource);
    }
}