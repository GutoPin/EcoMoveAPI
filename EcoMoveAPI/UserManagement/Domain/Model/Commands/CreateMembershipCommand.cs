namespace EcoMoveAPI.UserManagement.Domain.Model.Commands;

/**
 * Command to create a membership.
 * <param name="UserId">The user id of the user to create the membership for.</param>
 * <param name="MembershipCategoryId">The membership category id of the membership category to create the membership for.</param>
 * <remarks>
 * This command is used to create a membership for a user.
 * </remarks>
 * <returns>The created membership.</returns>
 */
public record CreateMembershipCommand(int UserId, int MembershipCategoryId);