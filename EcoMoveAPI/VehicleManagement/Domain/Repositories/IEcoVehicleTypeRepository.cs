using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;

namespace EcoMoveAPI.VehicleManagement.Domain.Repositories;

/**
 * IEcoVehicleTypeRepository interface
 * 
 */
public interface IEcoVehicleTypeRepository : IBaseRepository<EcoVehicleType>
{
    Task<EcoVehicleType?> FindEcoVehicleTypeByEcoVehicleTypeIdAsync(int ecoVehicleTypeId);
    
    Task<IEnumerable<EcoVehicleType>> FindAllEcoVehicleTypesAsync();
}