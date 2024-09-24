using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace EcoMoveAPI.VehicleManagement.Domain.Model.Aggregates;

public partial class EcoVehicle : IEntityWithCreatedUpdatedDate
{
    [Column ("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column ("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}