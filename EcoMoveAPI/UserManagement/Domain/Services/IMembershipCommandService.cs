using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Commands;

namespace EcoMoveAPI.UserManagement.Domain.Services;

/**
 * IMembershipCommandService interface
 * Represents a service for memberships
 */
public interface IMembershipCommandService
{
    public Task<Membership> Handle(CreateMembershipCommand command);
}