using EcoMoveAPI.BookingReservation.Application.Internal.OutboundServices.ACL;
using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.BookingReservation.Domain.Model.Commands;
using EcoMoveAPI.BookingReservation.Domain.Repositories;
using EcoMoveAPI.BookingReservation.Domain.Services;
using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.Shared.Application.Internal.OutboundServices;

namespace EcoMoveAPI.BookingReservation.Application.Internal.CommandServices;


public class BookingCommandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork, ExternalUserService externalUserService, ExternalEcoVehicleService externalEcoVehicleService) : IBookingCommandService
{
    public async Task<Booking?> Handle(CreateBookingCommand command)
    {
        var booking = new Booking(command);
        try
        {
            var user = await externalUserService.FetchUserByUserId(command.UserId);
            booking.User = user;
            var vehicle = await externalEcoVehicleService.FetchEcoVehicleById(command.VehicleId);
            booking.EcoVehicle = vehicle;
            await bookingRepository.AddAsync(booking);
            await unitOfWork.CompleteAsync();
            return booking;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the booking: {e.Message}");
            return null;
        }
    }
}