using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Queries;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Services;

namespace EcoMoveAPI.VehicleManagement.Application.Internal.QueryServices;

public class EcoVehicleQueryService(IEcoVehicleRepository ecoVehicleRepository) : IEcoVehicleQueryService
{
    public async Task<EcoVehicle?> Handle(GetEcoVehicleByEcoVehicleIdQuery query)
    {
        return await ecoVehicleRepository.FindEcoVehicleByEcoVehicleIdAsync(query.EcoVehicleId);
    }
    
    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesQuery query)
    {
        return await ecoVehicleRepository.FindAllEcoVehiclesAsync();
    }
    
    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByEcoVehicleTypeIdAndModelQuery query)
    {
        return await ecoVehicleRepository.FindAllEcoVehiclesByEcoVehicleTypeIdAndModelAsync(query.EcoVehicleTypeId, query.Model);
    }
    
    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByBatteryLevelGreaterThanQuery query)
    {
        return await ecoVehicleRepository.FindAllEcoVehiclesByBatteryLevelGreaterThanAsync(query.BatteryLevel);
    }
    
    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByStatusQuery query)
    {
        return await ecoVehicleRepository.FindAllEcoVehiclesByStatusAsync(query.Status);
    }
    
    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByEcoVehicleTypeIdQuery idQuery)
    {
        return await ecoVehicleRepository.FindAllEcoVehiclesByEcoVehicleTypeIdAsync(idQuery.EcoVehicleTypeId);
    }

    public async Task<IEnumerable<EcoVehicle>> Handle(GetAllEcoVehiclesByUserId query)
    {
        return await ecoVehicleRepository.FindAllEcoVehicleByUserId(query.UserId);
    }

}