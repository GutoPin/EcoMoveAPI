using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Entities;

namespace EcoMoveAPI.UserManagement.Domain.Repositories;

/**
 * IMembershipCategoryRepository interface
 * Represents a repository for membership categories
 * A membership category is a type of membership
 */
public interface IMembershipCategoryRepository: IBaseRepository<MembershipCategory>
{ }