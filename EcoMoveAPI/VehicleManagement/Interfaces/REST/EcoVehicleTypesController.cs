using System.Net.Mime;
using EcoMoveAPI.VehicleManagement.Domain.Model.Queries;
using EcoMoveAPI.VehicleManagement.Domain.Services;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class EcoVehicleTypesController 
    (IEcoVehicleTypeCommandService ecoVehicleTypeCommandService, IEcoVehicleTypeQueryService ecoVehicleTypeQueryService) : ControllerBase
{
    /**
     * Create Eco Vehicle Type.
     * <summary>
     *     Creates an eco vehicle type
     * </summary>
     * <param name="createEcoVehicleTypeResource">The resource containing the information to create an eco vehicle type.</param>
     * <returns>The newly created eco vehicle type resource.</returns>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates an eco vehicle type",
        Description = "Creates an eco vehicle type with a given name",
        OperationId = "CreateEcoVehicleType")]
    [SwaggerResponse(201, "The eco vehicle type was created", typeof(EcoVehicleTypeResource))]
    public async Task<IActionResult> CreateEcoVehicleType([FromBody] CreateEcoVehicleTypeResource createEcoVehicleTypeResource)
    {
        var createEcoVehicleTypeCommand =
            CreateEcoVehicleTypeCommandFromResourceAssembler.ToCommandFromResource(createEcoVehicleTypeResource);
        var ecoVehicleType = await ecoVehicleTypeCommandService.Handle(createEcoVehicleTypeCommand);
        if (ecoVehicleType is null) return BadRequest();
        var resource = EcoVehicleTypeResourceFromEntityAssembler.ToResourceFromEntity(ecoVehicleType);
        return CreatedAtAction(nameof(GetEcoVehicleTypeById), new { ecoVehicleTypeId = resource.Id }, resource);
    }
    
    /**
     * Get All Eco Vehicle Types.
     * <summary>
     *     Gets all eco vehicle types
     * </summary>
     * <returns>The eco vehicle types resources.</returns>
     */
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all eco vehicle types",
        Description = "Gets all eco vehicle types",
        OperationId = "GetAllEcoVehicleTypes")]
    [SwaggerResponse(200, "The eco vehicle types were found", typeof(EcoVehicleTypeResource))]
    public async Task<IActionResult> GetAllEcoVehicleTypes()
    {
        var getAllEcoVehicleTypesQuery = new GetAllEcoVehicleTypesQuery();
        var ecoVehicleTypes = await ecoVehicleTypeQueryService.Handle(getAllEcoVehicleTypesQuery);
        var ecoVehicleTypeResources = ecoVehicleTypes.Select(EcoVehicleTypeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleTypeResources);
    }
    
    /**
     * Get Eco Vehicle Type By Id.
     * <summary>
     *     Gets an eco vehicle type by its id.
     * </summary>
     * <param name="ecoVehicleTypeId">The eco vehicle type identifier.</param>
     * <returns>The eco vehicle type resource.</returns>
     */
    [HttpGet("{ecoVehicleTypeId:int}")]
    [SwaggerOperation(
        Summary = "Gets an eco vehicle type by id",
        Description = "Gets an eco vehicle type for a given identifier",
        OperationId = "GetEcoVehicleTypeById")]
    [SwaggerResponse(200, "The eco vehicle type was found", typeof(EcoVehicleTypeResource))]
    public async Task<IActionResult> GetEcoVehicleTypeById(int ecoVehicleTypeId)
    {
        var getEcoVehicleTypeByIdQuery = new GetEcoVehicleTypeByEcoVehicleTypeIdQuery(ecoVehicleTypeId);
        var ecoVehicleType = await ecoVehicleTypeQueryService.Handle(getEcoVehicleTypeByIdQuery);
        if (ecoVehicleType is null) return NotFound();
        var resource = EcoVehicleTypeResourceFromEntityAssembler.ToResourceFromEntity(ecoVehicleType);
        return Ok(resource);
    }
}