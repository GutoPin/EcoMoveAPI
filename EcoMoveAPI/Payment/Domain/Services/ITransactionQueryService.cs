using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Model.Queries;

namespace EcoMoveAPI.Payment.Domain.Services;

public interface ITransactionQueryService
{
    Task<IEnumerable<Transaction>> Handle(GetAllTransactionsByUserIdQuery query);
}