using EcoMoveAPI.UserManagement.Domain.Model.Entities;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;

namespace EcoMoveAPI.UserManagement.Domain.Services;

/**
 * IMembershipCategoryQueryService interface
 * Represents a service for membership categories
 * A membership category is a type of membership
 */
public interface IMembershipCategoryQueryService
{
    Task<MembershipCategory?> Handle(GetMembershipCategoryByMembershipCategoryIdQuery query);
}