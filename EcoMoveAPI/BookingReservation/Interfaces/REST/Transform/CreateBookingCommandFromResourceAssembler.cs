using EcoMoveAPI.BookingReservation.Domain.Model.Commands;
using EcoMoveAPI.BookingReservation.Interfaces.REST.Resources;

namespace EcoMoveAPI.BookingReservation.Interfaces.REST.Transform;

public static class CreateBookingCommandFromResourceAssembler
{
    public static CreateBookingCommand ToCommandFromResource(CreateBookingResource resource)
    {
        return new CreateBookingCommand(resource.UserId, resource.VehicleId, resource.StartTime, resource.EndTime, resource.Status);
    }
}