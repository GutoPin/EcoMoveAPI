using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.BookingReservation.Infrastructure.Persistence.EFC.Repositories;

public class BookingRepository(AppDbContext context) : BaseRepository<Booking>(context), IBookingRepository 
{
    public Task<Booking?> FindBookingByIdAsync(int id)
    {
        return Context.Set<Booking>().Where(b => b.BookingId == id).FirstOrDefaultAsync();
    }
    
    public async Task<IEnumerable<Booking>> FindAllBookingsByUserIdAsync(int userId)
    {
        return await Context.Set<Booking>().Where(b => b.UserId == userId).ToListAsync();
    }
}