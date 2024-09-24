using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Model.Commands;

namespace EcoMoveAPI.BookingReservation.Domain.Services;

public interface IBookingCommandService
{
    Task<Booking?> Handle(CreateBookingCommand command);
    
}