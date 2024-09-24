using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
/**
 * <summary>
 * Represents a customer support agent.
 * A customer support agent is a person who provides support to users.
 * </summary>
 */
public partial class CustomerSupportAgent : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}