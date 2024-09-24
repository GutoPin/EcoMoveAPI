using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.UserManagement.Domain.Repositories;

/**
 * IMembershipRepository interface
 * Represents a repository for memberships
 * A membership is a user's membership
 */
public interface IMembershipRepository : IBaseRepository<Membership>
{
    Task<Membership?> FindByUserIdAsync(int userId);
}