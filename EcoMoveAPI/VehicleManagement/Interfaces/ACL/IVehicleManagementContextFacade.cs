using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.VehicleManagement.Interfaces.ACL;

/**
 * IVehicleManagementContextFacade interface
 */
public interface IVehicleManagementContextFacade
{ 
    Task<EcoVehicle?> FetchVehicleByVehicleId(int vehicleId);
}