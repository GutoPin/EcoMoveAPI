using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.Payment.Domain.Repositories;

/**
 * Interface for the Transaction Repository
 * <summary>
 *   This interface is used to define the methods that the Transaction Repository must implement.
 * </summary>
 */
public interface ITransactionRepository : IBaseRepository<Transaction>
{
    Task<IEnumerable<Transaction>> FindAllTransactionsByUserIdAsync(int UserId);
}