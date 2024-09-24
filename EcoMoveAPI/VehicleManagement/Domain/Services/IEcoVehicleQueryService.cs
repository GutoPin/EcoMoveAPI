using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Queries;

namespace EcoMoveAPI.VehicleManagement.Domain.Services;

/**
 * IEcoVehicleQueryService interface
 */
public interface IEcoVehicleQueryService
{
    Task<EcoVehicle?> Handle(GetEcoVehicleByEcoVehicleIdQuery query);
    Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesQuery query);
    Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByEcoVehicleTypeIdAndModelQuery query);
    Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByBatteryLevelGreaterThanQuery query);
    Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByStatusQuery query);
    Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByEcoVehicleTypeIdQuery idQuery);
}