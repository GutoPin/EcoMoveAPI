using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.Repositories;
using EcoMoveAPI.VehicleManagement.Domain.Services;

namespace EcoMoveAPI.VehicleManagement.Application.Internal.CommandServices;

public class EcoVehicleTypeCommandService(IEcoVehicleTypeRepository ecoVehicleTypeRepository, IUnitOfWork unitOfWork) : IEcoVehicleTypeCommandService
{
    public async Task<EcoVehicleType?> Handle(CreateEcoVehicleTypeCommand command)
    {
        var ecoVehicleType = new EcoVehicleType(command.Name);
        await ecoVehicleTypeRepository.AddAsync(ecoVehicleType);
        await unitOfWork.CompleteAsync();
        return ecoVehicleType;
    }
}