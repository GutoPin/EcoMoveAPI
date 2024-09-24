using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.VehicleManagement.Infrastructure.Persistence.EFC.Repositories;

/**
 * EcoVehicleTypeRepository class
 * <param name="context"></param>
 * Represents the repository for the EcoVehicleType entity
 */
public class EcoVehicleTypeRepository(AppDbContext context)
    : BaseRepository<EcoVehicleType>(context), IEcoVehicleTypeRepository
{
    public Task<EcoVehicleType?> FindEcoVehicleTypeByEcoVehicleTypeIdAsync(int ecoVehicleTypeId)
    {
        return Context.Set<EcoVehicleType>().FirstOrDefaultAsync(ecoVehicleType => ecoVehicleType.EcoVehicleTypeId == ecoVehicleTypeId);
    }
    
    public async Task<IEnumerable<EcoVehicleType>> FindAllEcoVehicleTypesAsync()
    {
        return await Context.Set<EcoVehicleType>().ToListAsync();
    }
}