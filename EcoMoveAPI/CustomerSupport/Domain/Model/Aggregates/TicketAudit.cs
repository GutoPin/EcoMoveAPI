using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;

/**
 * <summary>
 * Represents a ticket.
 * A ticket is a request for support from a user.
 * </summary>
 */
public partial class Ticket : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}