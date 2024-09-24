using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Interfaces.ACL;

namespace EcoMoveAPI.BookingReservation.Application.Internal.OutboundServices.ACL;

public class ExternalEcoVehicleService(IVehicleManagementContextFacade vehicleManagementContextFacade)
{
    public async Task<EcoVehicle> FetchEcoVehicleById(int id)
    {
        var vehicle = await vehicleManagementContextFacade.FetchVehicleByVehicleId(id);
        if (vehicle == null)
        {
            throw new BadHttpRequestException("There is no vehicle found with id + " + id + ". ");
        }
        return vehicle;
    }
}