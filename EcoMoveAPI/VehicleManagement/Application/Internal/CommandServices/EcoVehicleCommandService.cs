using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Services;

namespace EcoMoveAPI.VehicleManagement.Application.Internal.CommandServices;

public class EcoVehicleCommandService(IEcoVehicleRepository ecoVehicleRepository, IUnitOfWork unitOfWork) : IEcoVehicleCommandService 
{
    public async Task<EcoVehicle?> Handle(CreateEcoVehicleCommand command)
    {
        var ecoVehicle = new EcoVehicle(command);
        try
        {
            await ecoVehicleRepository.AddAsync(ecoVehicle);
            await unitOfWork.CompleteAsync();
            return ecoVehicle;
        } 
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the ecoVehicle: {e.Message}");
            throw;
        }
    }
}