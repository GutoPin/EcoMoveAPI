namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

/**
 * EcoVehicleTypeResource record
 * Represents a EcoVehicleTypeResource
 * <param name="Id">The id of the EcoVehicleType</param>
 * <param name="Name">The name of the EcoVehicleType</param>
 * <returns>The resource of an eco vehicle type</returns>
 */
public record EcoVehicleTypeResource(int Id, string Name);