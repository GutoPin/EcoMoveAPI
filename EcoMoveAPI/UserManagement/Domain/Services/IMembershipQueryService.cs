using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;

namespace EcoMoveAPI.UserManagement.Domain.Services;

/**
 * IMembershipQueryService interface
 * Represents a service for memberships
 
 */
public interface IMembershipQueryService
{
    Task<Membership?> Handle(GetMembershipByMembershipIdQuery query);
    Task<Membership?> Handle(GetMembershipByUserIdQuery query);
}