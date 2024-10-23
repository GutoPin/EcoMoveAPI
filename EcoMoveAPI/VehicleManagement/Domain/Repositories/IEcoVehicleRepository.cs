using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.VehicleManagement.Domain.Repositories;

/**
 * IEcoVehicleRepository interface
 */
public interface IEcoVehicleRepository : IBaseRepository<EcoVehicle>
{
    Task<EcoVehicle?> FindEcoVehicleByEcoVehicleIdAsync(int ecoVehicleId);
    
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesAsync();
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByEcoVehicleTypeIdAndModelAsync(int EcoVehicleTypeId, string model);
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByEcoVehicleTypeIdAsync(int EcoVehicleTypeId);
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByStatusAsync(string status);
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByBatteryLevelGreaterThanAsync(int batteryLevel);
    Task<IEnumerable<EcoVehicle>> FindAllEcoVehicleByUserId(int userId);
}