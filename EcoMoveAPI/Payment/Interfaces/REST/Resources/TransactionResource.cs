namespace EcoMoveAPI.Payment.Interfaces.REST.Resources;

/**
 * Represents a transaction resource.
 * <param name="Id">The transaction ID.</param>
 * <param name="UserId">The user ID.</param>
 * <param name="Amount">The amount of the transaction.</param>
 * <param name="Date">The date of the transaction.</param>
 */
public record TransactionResource(int Id, int UserId, double Amount, DateTime Date);