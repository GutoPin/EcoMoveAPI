using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Model.Entities;

namespace EcoMoveAPI.UserManagement.Domain.Services;

/**
 * IMembershipCategoryCommandService interface
 * Represents a service for membership categories
 */
public interface IMembershipCategoryCommandService
{
    public Task<MembershipCategory?> Handle(CreateMembershipCategoryCommand command);
}