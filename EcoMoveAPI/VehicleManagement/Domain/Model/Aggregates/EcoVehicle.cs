using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.VehicleManagement.Domain.Model.Commands;
using EcoMoveAPI.VehicleManagement.Domain.Model.Entities;
using EcoMoveAPI.VehicleManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

public partial class EcoVehicle
{
    public EcoVehicle()
    {
        Model = string.Empty;
        EcoVehicleTypeId = 0;
        BatteryLevel = 0;
        Location = new Location(0, 0);
        Status = string.Empty;
        ImageUrl = string.Empty;
        UserId = 0;
    }
    
    public EcoVehicle(string model, int ecoVehicleTypeId, int batteryLevel, double latitude, double longitude, string status, string imageUrl, int userId)
    {
        Model = model;
        EcoVehicleTypeId = ecoVehicleTypeId;
        BatteryLevel = batteryLevel;
        Location = new Location(latitude, longitude);
        Status = status;
        ImageUrl = imageUrl;
        UserId = userId;
    }

    public EcoVehicle(CreateEcoVehicleCommand command)
    {
        Model = command.Model;
        EcoVehicleTypeId = command.EcoVehicleTypeId;
        BatteryLevel = command.BatteryLevel;
        Location = new Location(command.Latitude, command.Longitude);
        Status = command.Status;
        ImageUrl = command.ImageUrl;
        UserId = command.UserId;
    }
    
    public int EcoVehicleId { get; private set; }
    public string Model { get; private set; }
    public EcoVehicleType EcoVehicleType { get; internal set; }
    public int EcoVehicleTypeId { get; private set; }
    public int BatteryLevel { get; private set; }
    public Location Location { get; private set; }
    public string Status { get; private set; }
    public string ImageUrl { get; private set; }
    public int UserId { get; private set; }

    public object FullLocation => Location.GetLocationObject();
    
    public ICollection<Booking> Bookings { get; }
    
}