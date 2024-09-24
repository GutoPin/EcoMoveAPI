using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Model.Commands;
using EcoMoveAPI.Payment.Domain.Repositories;
using EcoMoveAPI.Payment.Domain.Services;
using EcoMoveAPI.Shared.Application.Internal.OutboundServices;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.Payment.Application.Internal.CommandServices;

/**
 * Service for handling Transaction Commands
 * <summary>
 *   This service is used to handle the commands related to Transactions.
 * </summary>
 * <remarks>
 *  This class implements the ITransactionCommandService interface.
 * </remarks>
 * <param name="transactionRepository">The repository for the Transaction entity</param>
 * <param name="unitOfWork">The unit of work for the database</param>
 * <param name="externalUserService">The service for external user operations</param>
 */

public class TransactionCommandService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, ExternalUserService externalUserService) : ITransactionCommandService 
{
    public async Task<Transaction?> Handle(CreateTransactionCommand command)
    {
        var transaction = new Transaction(command);
        try
        {
            var user = await externalUserService.FetchUserByUserId(command.UserId);
            transaction.User = user;
            await transactionRepository.AddAsync(transaction);
            await unitOfWork.CompleteAsync();
            return transaction;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the transaction: {e.Message}");
            return null;
        }
    }
}