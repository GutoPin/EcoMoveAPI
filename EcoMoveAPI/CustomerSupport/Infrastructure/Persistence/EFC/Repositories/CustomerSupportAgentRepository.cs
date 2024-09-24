using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.CustomerSupport.Infrastructure.Persistence.EFC.Repositories;

public class CustomerSupportAgentRepository(AppDbContext context)
    : BaseRepository<CustomerSupportAgent>(context), ICustomerSupportAgentRepository
{
    public Task<CustomerSupportAgent?> FindCustomerSupportAgentByIdAsync(int customerSupportAgentId)
    {
        return Context.Set<CustomerSupportAgent>().FirstOrDefaultAsync(agent => agent.CustomerSupportAgentId == customerSupportAgentId);
    }
}