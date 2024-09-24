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
public class CustomerSupportAgentsController(
    ICustomerSupportAgentCommandService customerSupportAgentCommandService,
    ICustomerSupportAgentQueryService customerSupportAgentQueryService)
    : ControllerBase
{
    /**
     * Create Customer Support Agents.
     * <summary>
     *     This method is responsible for handling the request to create a new customer support agent
     * </summary>
     * <param name="createCustomerSupportAgentResource">The resource containing the information to create a new customer support agent.</param>
     * <returns>The newly created customer support agent resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a customer support agent",
        Description = "Creates a customer support agent with a given name and email address",
        OperationId = "CreateCustomerSupportAgent")]
    [SwaggerResponse(201, "The customer support agent was created", typeof(CustomerSupportAgentResource))]
    public async Task<IActionResult> CreateCustomerSupportAgent([FromBody] CreateCustomerSupportAgentResource createCustomerSupportAgentResource)
    {
        var createCustomerSupportAgentCommand =
            CreateCustomerSupportAgentCommandFromResourceAssembler.ToCommandFromResource(createCustomerSupportAgentResource);
        var customerSupportAgent = await customerSupportAgentCommandService.Handle(createCustomerSupportAgentCommand);
        if (customerSupportAgent is null) return BadRequest();
        var resource = CustomerSupportAgentResourceFromEntityAssembler.ToResourceFromEntity(customerSupportAgent);
        return CreatedAtAction(nameof(GetCustomerSupportAgentById), new { customerSupportAgentId = resource.Id }, resource);
    }
    
    /**
     * Get Customer Support Agent By Id.
     * <summary>
     *     This method is responsible for handling the request to get a customer support agent by its id.
     * </summary>
     * <param name="customerSupportAgentId">The customer support agent identifier.</param>
     * <returns>The customer support agent resource.</returns>
     */
    [HttpGet("{customerSupportAgentId:int}")]
    [SwaggerOperation(
        Summary = "Gets a customer support agent by id",
        Description = "Gets a customer support agent for a given identifier",
        OperationId = "GetCustomerSupportById")]
    [SwaggerResponse(200, "The customer support agent was found", typeof(CustomerSupportAgentResource))]
    public async Task<IActionResult> GetCustomerSupportAgentById(int customerSupportAgentId)
    {
        var getCustomerSupportAgentByIdQuery = new GetCustomerSupportAgentByCustomerSupportAgentIdQuery(customerSupportAgentId);
        var customerSupportAgent = await customerSupportAgentQueryService.Handle(getCustomerSupportAgentByIdQuery);
        if (customerSupportAgent is null) return NotFound();
        var resource = CustomerSupportAgentResourceFromEntityAssembler.ToResourceFromEntity(customerSupportAgent);
        return Ok(resource);
    }
}