namespace EcoMoveAPI.Payment.Domain.Model.Commands;

/**
 * Command to create a transaction.
 * <param name="UserId">The user ID.</param>
 * <param name="Amount">The amount of the transaction.</param>
 * <param name="Date">The date of the transaction.</param>
 * <returns>The created transaction.</returns>
 */
public record CreateTransactionCommand(int UserId, double Amount, DateTime Date);