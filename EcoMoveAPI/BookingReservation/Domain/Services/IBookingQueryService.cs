using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Model.Queries;

namespace EcoMoveAPI.BookingReservation.Domain.Services;

public interface IBookingQueryService
{
    Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query);
    Task<IEnumerable<Booking>> Handle(GetAllBookingsByUserIdQuery query);
    Task<Booking?> Handle(GetBookingByBookingIdQuery query);
}