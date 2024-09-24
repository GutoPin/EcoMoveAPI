namespace EcoMoveAPI.UserManagement.Domain.Model.Queries;

/**
 * Query to get a membership by its membership id.
 * <param name="MembershipId">The id of the membership.</param>
 * <remarks>
 * This query is used to get a membership by its membership id.
 * </remarks>
 * <returns>The membership with the specified membership id.</returns>
 */
public record GetMembershipByMembershipIdQuery(int MembershipId);