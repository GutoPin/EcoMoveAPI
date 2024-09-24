using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Interfaces.REST.Resources;

namespace EcoMoveAPI.BookingReservation.Interfaces.REST.Transform;

public static class BookingResourceFromEntityAssembler
{
    public static BookingResource ToResourceFromEntity(Booking entity)
    {
        return new BookingResource(entity.BookingId, entity.UserId, entity.VehicleId, entity.StartTime, entity.EndTime, entity.Status);
    }
}