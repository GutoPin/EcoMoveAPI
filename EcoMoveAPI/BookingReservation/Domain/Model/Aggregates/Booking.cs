using EcoMoveAPI.BookingReservation.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;

public class Booking
{
    public Booking()
    {
        UserId = 0;
        VehicleId = 0;
        StartTime = DateTime.Now;
        EndTime = DateTime.Now;
        Status = String.Empty;
    }
    
    public Booking(int userId, int vehicleId, DateTime startTime, DateTime endTime, string status)
    {
        UserId = userId;
        VehicleId = vehicleId;
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
    }

    public Booking(CreateBookingCommand command)
    {
        UserId = command.UserId;
        VehicleId = command.VehicleId;
        StartTime = command.StartTime;
        EndTime = command.EndTime;
        Status = command.Status;
    }
    
    public int BookingId { get; private set; }
    public User User { get; internal set; }
    public int UserId { get; private set; }
    public EcoVehicle EcoVehicle { get; internal set; }
    public int VehicleId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public string Status { get; private set; }
}