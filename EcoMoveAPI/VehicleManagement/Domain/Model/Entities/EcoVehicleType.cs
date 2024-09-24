using EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.VehicleManagement.Domain.Model.Entities;

public class EcoVehicleType
{
    public EcoVehicleType()
    {
        Name = string.Empty;
    }

    public EcoVehicleType(string name)
    {
        Name = name;
    }
    
    public int EcoVehicleTypeId { get; set; }
    public string Name { get; set; }
    public ICollection<EcoVehicle> EcoVehicles { get; }
}