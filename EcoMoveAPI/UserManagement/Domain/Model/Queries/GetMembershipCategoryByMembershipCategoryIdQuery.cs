namespace EcoMoveAPI.UserManagement.Domain.Model.Queries;
/**
 * Query to get a membership category by its membership category id.
 * <param name="MembershipCategoryId">The id of the membership category.</param>
 * <remarks>
 * This query is used to get a membership category by its membership category id.
 * </remarks>
 * <returns>The membership category with the specified membership category id.</returns>
 */
public record GetMembershipCategoryByMembershipCategoryIdQuery(int MembershipCategoryId);