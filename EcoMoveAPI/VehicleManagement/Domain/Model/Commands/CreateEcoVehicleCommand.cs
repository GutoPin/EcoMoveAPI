namespace EcoMoveAPI.VehicleManagement.Domain.Model.Commands;

public record CreateEcoVehicleCommand(string Model, int EcoVehicleTypeId, int BatteryLevel, double Latitude, double Longitude, string Status, string ImageUrl, int UserId);