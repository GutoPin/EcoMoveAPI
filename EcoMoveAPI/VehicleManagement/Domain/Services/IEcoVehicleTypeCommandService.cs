using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;

namespace EcoMoveAPI.VehicleManagement.Domain.Services;

public interface IEcoVehicleTypeCommandService
{
    public Task<EcoVehicleType?> Handle(CreateEcoVehicleTypeCommand command);
}