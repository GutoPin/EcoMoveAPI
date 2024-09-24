namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

/**
 * CreateEcoVehicleResource record
 * Represents the data required to create a new EcoVehicle
 * <param name="Model">The model of the EcoVehicle</param>
 * <param name="EcoVehicleTypeId">The id of the EcoVehicleType</param>
 * <param name="BatteryLevel">The battery level of the EcoVehicle</param>
 * <param name="Latitude">The latitude of the EcoVehicle</param>
 * <param name="Longitude">The longitude of the EcoVehicle</param>
 * <param name="Status">The status of the EcoVehicle</param>
 * <param name="ImageUrl">The image URL of the EcoVehicle</param>
 * <returns>The data required to create a new EcoVehicle</returns>
 */
public record CreateEcoVehicleResource(string Model, int EcoVehicleTypeId, int BatteryLevel, double Latitude, double Longitude, string Status, string ImageUrl);