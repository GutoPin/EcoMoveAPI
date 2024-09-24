using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.VehicleManagement.Infrastructure.Persistence.EFC.Repositories;

/**
 * EcoVehicleRepository class
 * Represents the repository for the EcoVehicle entity
 * <param name="context">AppDbContext instance</param>
 */
public class EcoVehicleRepository(AppDbContext context) : BaseRepository<EcoVehicle>(context), IEcoVehicleRepository
{
    public Task<EcoVehicle?> FindEcoVehicleByEcoVehicleIdAsync(int ecoVehicleId)
    {
        return Context.Set<EcoVehicle>().FirstOrDefaultAsync(ecoVehicle => ecoVehicle.EcoVehicleId == ecoVehicleId);
    }
    
    public async Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesAsync()
    {
        return await Context.Set<EcoVehicle>().ToListAsync();
    }
    
    public async Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByEcoVehicleTypeIdAndModelAsync(int ecoVehicleTypeId, string model)
    {
        if (ecoVehicleTypeId < 0 || string.IsNullOrEmpty(model))
        {
            throw new ArgumentException("Type and model must be provided.");
        }

        var result = await Context.Set<EcoVehicle>()
            .Where(ecoVehicle => ecoVehicle.EcoVehicleId == ecoVehicleTypeId && ecoVehicle.Model == model)
            .ToListAsync();

        return result.AsEnumerable();
    }
    
    public async Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByBatteryLevelGreaterThanAsync(int batteryLevel)
    {
        if (batteryLevel < 0)
        {
            throw new ArgumentException("Battery level must be greater than 0.");
        }

        var result = await Context.Set<EcoVehicle>()
            .Where(ecoVehicle => ecoVehicle.BatteryLevel > batteryLevel)
            .ToListAsync();

        return result.AsEnumerable();
    }
    
    public async Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByStatusAsync(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            throw new ArgumentException("Type and status must be provided.");
        }

        var result = await Context.Set<EcoVehicle>()
            .Where(ecoVehicle => ecoVehicle.Status == status)
            .ToListAsync();

        return result.AsEnumerable();
    }
    
    public async Task<IEnumerable<EcoVehicle>> FindAllEcoVehiclesByEcoVehicleTypeIdAsync(int ecoVehicleTypeId)
    {
        if (ecoVehicleTypeId < 0)
        {
            throw new ArgumentException("Type must be provided.");
        }

        var result = await Context.Set<EcoVehicle>()
            .Where(ecoVehicle => ecoVehicle.EcoVehicleId == ecoVehicleTypeId)
            .ToListAsync();

        return result.AsEnumerable();
    }
    
}