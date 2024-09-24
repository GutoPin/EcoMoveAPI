using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.BookingReservation.Domain.Repositories;

public interface IBookingRepository : IBaseRepository<Booking>
{
    Task<Booking?> FindBookingByIdAsync(int booking);
    Task<IEnumerable<Booking>> FindAllBookingsByUserIdAsync(int userId);
}