namespace EcoMoveAPI.BookingReservation.Domain.Model.Commands;

public record CreateBookingCommand(int UserId, int VehicleId, DateTime StartTime, DateTime EndTime, string Status);