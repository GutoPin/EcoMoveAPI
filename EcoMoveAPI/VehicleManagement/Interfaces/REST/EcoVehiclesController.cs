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
public class EcoVehiclesController(IEcoVehicleCommandService ecoVehicleCommandService, IEcoVehicleQueryService ecoVehicleQueryService)
    : ControllerBase
{
    /**
     * <summary>
     *      Creates an eco vehicle
     * </summary>
     * <remarks>
     *      Creates an eco vehicle with a given model, type, battery level, latitude, longitude, status and image URL
     * </remarks>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates an eco vehicle",
        Description = "Creates an eco vehicle with a given model, type, battery level, latitude, longitude, status and image URL",
        OperationId = "CreateEcoVehicle")]
    [SwaggerResponse(201, "The eco vehicle was created", typeof(EcoVehicleResource))]
    public async Task<IActionResult> CreateEcoVehicle([FromBody] CreateEcoVehicleResource resource)
    {
        var createEcoVehicleCommand = CreateEcoVehicleCommandFromResourceAssembler.ToCommandFromResource(resource);
        var ecoVehicle = await ecoVehicleCommandService.Handle(createEcoVehicleCommand);
        if (ecoVehicle is null) return BadRequest();
        var ecoVehicleResource = EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity(ecoVehicle);
        return CreatedAtAction(nameof(GetEcoVehicleByEcoVehicleId), new {ecoVehicleId = ecoVehicleResource.Id}, ecoVehicleResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles",
        Description = "Gets all eco vehicles",
        OperationId = "GetAllEcoVehicles")]
    [SwaggerResponse(200, "The eco vehicles were found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetAllEcoVehicles()
    {
        var getAllEcoVehiclesQuery = new GetAllEcoVehiclesQuery();
        var ecoVehicles = await ecoVehicleQueryService.Handle(getAllEcoVehiclesQuery);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }
    
    [HttpGet("id/{ecoVehicleId:int}")]
    [SwaggerOperation(
        Summary = "Gets an eco vehicle by id",
        Description = "Gets an eco vehicle for a given identifier",
        OperationId = "GetEcoVehicleByEcoVehicleId")]
    [SwaggerResponse(200, "The eco vehicle was found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetEcoVehicleByEcoVehicleId(int ecoVehicleId)
    {
        var getEcoVehicleByEcoVehicleIdQuery = new GetEcoVehicleByEcoVehicleIdQuery(ecoVehicleId);
        var ecoVehicle = await ecoVehicleQueryService.Handle(getEcoVehicleByEcoVehicleIdQuery);
        if (ecoVehicle == null) return NotFound();
        var ecoVehicleResource = EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity(ecoVehicle);
        return Ok(ecoVehicleResource);
    }
    
    [HttpGet("{ecoVehicleTypeId:int}")]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles by type",
        Description = "Gets all eco vehicles for a given type",
        OperationId = "GetAllEcoVehiclesByType")]
    [SwaggerResponse(200, "The eco vehicles were found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetAllEcoVehiclesByType(int ecoVehicleTypeId)
    {
        var getEcoVehiclesByTypeQuery = new GetAllEcoVehiclesByEcoVehicleTypeIdQuery(ecoVehicleTypeId);
        var ecoVehicles = await ecoVehicleQueryService.Handle(getEcoVehiclesByTypeQuery);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }
    
    [HttpGet("type/{ecoVehicleTypeId:int}/model/{model}")]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles by type and model",
        Description = "Gets all eco vehicles for a given type and model",
        OperationId = "GetAllEcoVehiclesByTypeAndModel")]
    [SwaggerResponse(200, "The eco vehicles were found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetAllEcoVehiclesByTypeAndModel(int ecoVehicleTypeId, string model)
    {
        var getEcoVehiclesByTypeAndModelQuery = new GetAllEcoVehiclesByEcoVehicleTypeIdAndModelQuery(ecoVehicleTypeId, model);
        var ecoVehicles = await ecoVehicleQueryService.Handle(getEcoVehiclesByTypeAndModelQuery);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }
    
    [HttpGet("battery-level/{batteryLevel:int}")]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles by battery level",
        Description = "Gets all eco vehicles for a given battery level",
        OperationId = "GetAllEcoVehiclesByBatteryLevel")]
    [SwaggerResponse(200, "The eco vehicles were found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetAllEcoVehiclesByBatteryLevelGreaterThan(int batteryLevel)
    {
        var getEcoVehiclesByBatteryLevelGreaterThanQuery = new GetAllEcoVehiclesByBatteryLevelGreaterThanQuery(batteryLevel);
        var ecoVehicles = await ecoVehicleQueryService.Handle(getEcoVehiclesByBatteryLevelGreaterThanQuery);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }
    
    [HttpGet("status/{status}")]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles by status",
        Description = "Gets all eco vehicles for a given status",
        OperationId = "GetAllEcoVehiclesByStatus")]
    [SwaggerResponse(200, "The eco vehicles were found", typeof(EcoVehicleResource))]
    public async Task<IActionResult> GetAllEcoVehiclesByStatus(string status)
    {
        var getEcoVehiclesByTypeAndStatusQuery = new GetAllEcoVehiclesByStatusQuery(status);
        var ecoVehicles = await ecoVehicleQueryService.Handle(getEcoVehiclesByTypeAndStatusQuery);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }

    
    [HttpGet("userid/{userId}")]
    [SwaggerOperation(
        Summary = "Gets all eco vehicles by userId",
        Description = "Gets all eco vehicles for a given userId",
        OperationId = "GetAllEcoVehiclesByUserId")]
    public async Task<IActionResult> GetAllEcoVehiclesByUserId(int userId)
    {
        var getEcoVehiclesByUserId = new GetAllEcoVehiclesByUserId(userId);
        var ecoVehicles = await ecoVehicleQueryService.Handle(getEcoVehiclesByUserId);
        var ecoVehicleResources = ecoVehicles.Select(EcoVehicleResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(ecoVehicleResources);
    }
}

