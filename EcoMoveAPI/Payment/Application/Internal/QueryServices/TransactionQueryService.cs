using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Model.Queries;
using EcoMoveAPI.Payment.Domain.Repositories;
using EcoMoveAPI.Payment.Domain.Services;

namespace EcoMoveAPI.Payment.Application.Internal.QueryServices;

/**
 * Service for handling transaction queries.
 * <param name="transactionRepository">The transaction repository.</param>
 * <remarks>
 * This class implements the ITransactionQueryService interface.
 * </remarks>
 */
public class TransactionQueryService(ITransactionRepository transactionRepository): ITransactionQueryService
{
    public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsByUserIdQuery query)
    {
        return await transactionRepository.FindAllTransactionsByUserIdAsync(query.UserId);
    }
}