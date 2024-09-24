using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Transform;

/**
 * EcoVehicleResourceFromEntityAssembler class
 */
public static class EcoVehicleResourceFromEntityAssembler
{
    /**
     * ToResourceFromEntity method
     * Convert EcoVehicle to EcoVehicleResource
     * <param name="entity">The EcoVehicle</param>
     * <returns>The EcoVehicleResource</returns>
     */
    public static EcoVehicleResource ToResourceFromEntity(EcoVehicle entity)
    {
        return new EcoVehicleResource(entity.EcoVehicleId, entity.Model, entity.EcoVehicleTypeId, entity.BatteryLevel,
            entity.Location, entity.Status, entity.ImageUrl);
    }
}