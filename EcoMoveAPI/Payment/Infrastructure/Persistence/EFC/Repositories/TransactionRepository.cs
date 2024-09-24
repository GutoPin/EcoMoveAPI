using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.Payment.Infrastructure.Persistence.EFC.Repositories;


/**
 * Transaction Repository
 * <summary>
 *  This class is used to interact with the database and perform CRUD operations on the Transaction entity.
 * </summary>
 * <remarks>
 *  This class extends the BaseRepository class and implements the ITransactionRepository interface.
 * </remarks>
 */
public class TransactionRepository(AppDbContext context): BaseRepository<Transaction>(context), ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> FindAllTransactionsByUserIdAsync(int UserId)
    {
        return await Context.Set<Transaction>().Where(t => t.UserId == UserId).ToListAsync();
    }
}