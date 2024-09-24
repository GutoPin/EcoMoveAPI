namespace EcoMoveAPI.VehicleManagement.Domain.Model.Queries;

/**
 * GetAllEcoVehiclesByEcoVehicleTypeIdAndModelQuery record
 */
public record GetAllEcoVehiclesByEcoVehicleTypeIdAndModelQuery(int EcoVehicleTypeId, string Model);