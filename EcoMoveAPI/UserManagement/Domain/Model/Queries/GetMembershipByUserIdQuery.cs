namespace EcoMoveAPI.UserManagement.Domain.Model.Queries;

/**
 * Query to get a membership by its user id.
 * <param name="UserId">The id of the user.</param>
 * <remarks>
 * This query is used to get a membership by its user id.
 * </remarks>
 * <returns>The membership with the specified user id.</returns>
 */
public record GetMembershipByUserIdQuery(int UserId);