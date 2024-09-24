namespace EcoMoveAPI.Payment.Domain.Model.Queries;

/**
 * Query to get all transactions by user id
 * <param name="UserId">The user ID.</param>
 * <returns>The transactions.</returns>
 */
public record GetAllTransactionsByUserIdQuery(int UserId);