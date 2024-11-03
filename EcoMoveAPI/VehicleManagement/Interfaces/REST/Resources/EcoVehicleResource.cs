using EcoMoveAPI.VehicleManagement.Domain.ValueObjects;

namespace EcoMoveAPI.VehicleManagement.Interfaces.REST.Resources;

/**
 * EcoVehicleResource class
 * Represents the resource of an eco vehicle
 * <param name="Id">The id of the EcoVehicle</param>
 * <param name="Model">The model of the EcoVehicle</param>
 * <param name="EcoVehicleTypeId">The id of the EcoVehicleType</param>
 * <param name="BatteryLevel">The battery level of the EcoVehicle</param>
 * <param name="Location">The location of the EcoVehicle</param>
 * <param name="Status">The status of the EcoVehicle</param>
 * <param name="ImageUrl">The image URL of the EcoVehicle</param>
 * <returns>The resource of an eco vehicle</returns>
 */
public record EcoVehicleResource(int Id, string Model, int EcoVehicleTypeId, int BatteryLevel, Location Location, string Status, string ImageUrl, string EcoVehicleName);