using System.Net.Mime;
using EcoMoveAPI.UserManagement.Application.Internal.CommandServices;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Services;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;
using EcoMoveAPI.UserManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.UserManagement.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MembershipsController(
    IMembershipCommandService membershipCommandService,
    IMembershipQueryService membershipQueryService
    ) : ControllerBase
{
    /**
     * <summary>
     *    Create Membership endpoint. It allows to create a new membership.
     * </summary>
     * <param name="createMembershipResource">The resource containing the information to create a new membership.</param>
     * <returns>The newly created membership resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a membership",
        Description = "Creates a membership with a given user id and membership category id",
        OperationId = "CreateMembership")]
    [SwaggerResponse(201, "The membership was created", typeof(MembershipResource))]
    public async Task<IActionResult> CreateMembership([FromBody] CreateMembershipResource createMembershipResource)
    {
        var createMembershipCommand =
            CreateMembershipCommandFromResourceAssembler.ToCommandFromResource(createMembershipResource);
        var membership = await membershipCommandService.Handle(createMembershipCommand);
        if (membership is null) return BadRequest();
        var resource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        return CreatedAtAction(nameof(GetMembershipById), new { membershipId = resource.Id }, resource);
    }
    
    /**
     * <summary>
     *    Get Membership By Id endpoint. It allows to get a membership by its id.
     * </summary>
     * <param name="membershipId">The membership identifier.</param>
     * <returns>The membership resource.</returns>
     */
    [HttpGet("{membershipId:int}")]
    [SwaggerOperation(
        Summary = "Gets a membership by id",
        Description = "Gets a membership for a given identifier",
        OperationId = "GetMembershipById")]
    [SwaggerResponse(200, "The membership was found", typeof(MembershipResource))]
    public async Task<IActionResult> GetMembershipById(int membershipId)
    {
        var getMembershipByIdQuery = new GetMembershipByMembershipIdQuery(membershipId);
        var membership = await membershipQueryService.Handle(getMembershipByIdQuery);
        if (membership is null) return NotFound();
        var resource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        return Ok(resource);
    }
    
    /**
     * <summary>
     *    Get Membership By User Id endpoint. It allows to get the latest membership for a user.
     * </summary>
     * <param name="userId">The user identifier.</param>
     * <returns>The latest membership resource.</returns>
     */
    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets a membership by user id",
        Description = "Gets the latest membership for a given user identifier",
        OperationId = "GetMembershipByUserId")]
    [SwaggerResponse(200, "The membership was found", typeof(MembershipResource))]
    public async Task<IActionResult> GetMembershipByUserId(int userId)
    {
        var getMembershipByUserIdQuery = new GetMembershipByUserIdQuery(userId);
        var membership = await membershipQueryService.Handle(getMembershipByUserIdQuery);
        if (membership is null) return NotFound();
        var resource = MembershipResourceFromEntityAssembler.ToResourceFromEntity(membership);
        return Ok(resource);
    }
    
}