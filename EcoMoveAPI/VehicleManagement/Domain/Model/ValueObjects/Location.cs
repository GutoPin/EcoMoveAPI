namespace EcoMoveAPI.VehicleManagement.Domain.ValueObjects;

/**
 * Location record
 * <param name="Latitude">Latitude</param>
 * <param name="Longitude">Longitude</param>
 */
public record Location(double Latitude, double Longitude)
{
    public Location() : this(0, 0)
    {
    }
    
    public Location(double latitude) : this(latitude, 0)
    {
    }
    
    public object GetLocationObject()
    {
        return new 
        {
            Latitude,
            Longitude
        };
    }
}