using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.CustomerSupport.Infrastructure.Persistence.EFC.Repositories;

public class TicketRepository(AppDbContext context) : BaseRepository<Ticket>(context), ITicketRepository
{
    public async Task<IEnumerable<Ticket>> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Ticket>().Where(ticket => ticket.UserId == userId).ToListAsync();
    }
    
    public async Task<IEnumerable<Ticket>> FindByCustomerSupportAgentIdAsync(int agentId)
    {
        return await Context.Set<Ticket>().Where(ticket => ticket.CustomerSupportAgentId == agentId).ToListAsync();
    }
}