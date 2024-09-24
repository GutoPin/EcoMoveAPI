using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Transform;

/**
 * CreateEcoVehicleTypeCommandFromResourceAssembler class
 */
public static class CreateEcoVehicleTypeCommandFromResourceAssembler
{
    /**
     * ToCommandFromResource method
     * Convert CreateEcoVehicleTypeResource to CreateEcoVehicleTypeCommand
     * <param name="resource">The CreateEcoVehicleTypeResource</param>
     * <returns>The CreateEcoVehicleTypeCommand</returns>
     */
    public static CreateEcoVehicleTypeCommand ToCommandFromResource(this CreateEcoVehicleTypeResource resource)
    {
        return new CreateEcoVehicleTypeCommand(resource.Name);
    }
}