using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Model.Commands;

namespace EcoMoveAPI.Payment.Domain.Services;

public interface ITransactionCommandService
{
    Task<Transaction?> Handle(CreateTransactionCommand command);
}