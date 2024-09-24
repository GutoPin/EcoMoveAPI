namespace EcoMoveAPI.UserManagement.Domain.Model.Commands;

/**
 * Command to create a membership category.
 * <param name="Name">The name of the membership category.</param>
 */
public record CreateMembershipCategoryCommand(string Name);