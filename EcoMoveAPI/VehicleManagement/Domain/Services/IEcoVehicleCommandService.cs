using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;

namespace EcoMoveAPI.VehicleManagement.Domain.Services;

public interface IEcoVehicleCommandService
{
    Task<EcoVehicle?> Handle(CreateEcoVehicleCommand command);
}