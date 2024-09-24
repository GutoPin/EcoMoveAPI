namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

/**
 * CreateEcoVehicleTypeResource record
 * Represents a CreateEcoVehicleTypeResource
 * <param name="Name">The name of the EcoVehicleType</param>
 * <returns>The data required to create a new EcoVehicleType</returns>
 */
public record CreateEcoVehicleTypeResource(string Name);