using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.Model.Queries;

namespace EcoMoveAPI.VehicleManagement.Domain.Services;

/**
 * IEcoVehicleTypeQueryService interface
 */
public interface IEcoVehicleTypeQueryService
{
    Task<EcoVehicleType?> Handle(GetEcoVehicleTypeByEcoVehicleTypeIdQuery query);
    
    Task<IEnumerable<EcoVehicleType>> Handle(GetAllEcoVehicleTypesQuery query);
}