using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Transform;

/**
 * EcoVehicleTypeResourceFromEntityAssembler class
 */
public static class EcoVehicleTypeResourceFromEntityAssembler
{
    /**
     * ToResourceFromEntity method
     * Convert EcoVehicleType to EcoVehicleTypeResource
     * <param name="entity">The EcoVehicleType</param>
     * <returns>The EcoVehicleTypeResource</returns>
     */
    public static EcoVehicleTypeResource ToResourceFromEntity(EcoVehicleType entity)
    {
        return new EcoVehicleTypeResource(entity.EcoVehicleTypeId, entity.Name);
    }
}