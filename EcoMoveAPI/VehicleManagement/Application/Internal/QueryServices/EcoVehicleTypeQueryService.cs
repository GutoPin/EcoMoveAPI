using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.Model.Queries;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Services;

namespace EcoMoveAPI.VehicleManagement.Application.Internal.QueryServices;

public class EcoVehicleTypeQueryService(IEcoVehicleTypeRepository ecoVehicleTypeRepository) : IEcoVehicleTypeQueryService
{
    public async Task<EcoVehicleType?> Handle(GetEcoVehicleTypeByEcoVehicleTypeIdQuery query)
    {
        return await ecoVehicleTypeRepository.FindByIdAsync(query.EcoVehicleTypeId);
    }
    
    public async Task<IEnumerable<EcoVehicleType>> Handle(GetAllEcoVehicleTypesQuery query)
    {
        return await ecoVehicleTypeRepository.FindAllEcoVehicleTypesAsync();
    }
}