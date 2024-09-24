namespace EcoMoveAPI.VehicleManagement.Domain.Model.Queries;

public record GetAllEcoVehiclesByEcoVehicleTypeIdAndStatusQuery(int EcoVehicleTypeId, string Status);