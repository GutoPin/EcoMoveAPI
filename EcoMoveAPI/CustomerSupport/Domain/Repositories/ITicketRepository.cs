using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.CustomerSupport.Domain.Repositories;

public interface ITicketRepository : IBaseRepository<Ticket>
{
    Task<IEnumerable<Ticket>> FindByCustomerSupportAgentIdAsync(int customerId);
    Task<IEnumerable<Ticket>> FindByUserIdAsync(int agentId);
}