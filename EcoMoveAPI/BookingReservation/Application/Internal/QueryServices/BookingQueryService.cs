using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Model.Queries;
using EcoMoveAPI.BookingReservation.Domain.Repositories;
using EcoMoveAPI.BookingReservation.Domain.Services;

namespace EcoMoveAPI.BookingReservation.Application.Internal.QueryServices;

public class BookingQueryService(IBookingRepository bookingRepository) : IBookingQueryService
{
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
    {
        return await bookingRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsByUserIdQuery query)
    {
        return await bookingRepository.FindAllBookingsByUserIdAsync(query.UserId);
    }
    
    public async Task<Booking?> Handle(GetBookingByBookingIdQuery query)
    {
        return await bookingRepository.FindBookingByIdAsync(query.BookingId);
    }
}