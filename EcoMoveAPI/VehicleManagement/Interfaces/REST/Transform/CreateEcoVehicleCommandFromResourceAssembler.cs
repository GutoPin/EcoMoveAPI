using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Transform;

/**
 * CreateEcoVehicleCommandFromResourceAssembler class
 */
public static class CreateEcoVehicleCommandFromResourceAssembler
{
    /**
     * ToCommandFromResource method
     * Convert CreateEcoVehicleResource to CreateEcoVehicleCommand
     * <param name="resource">The CreateEcoVehicleResource</param>
     * <returns>The CreateEcoVehicleCommand</returns>
     */
    public static CreateEcoVehicleCommand ToCommandFromResource(CreateEcoVehicleResource resource)
    {
        return new CreateEcoVehicleCommand(resource.Model, resource.EcoVehicleTypeId, resource.BatteryLevel, resource.Latitude,
            resource.Longitude, resource.Status, resource.ImageUrl);
    }
}