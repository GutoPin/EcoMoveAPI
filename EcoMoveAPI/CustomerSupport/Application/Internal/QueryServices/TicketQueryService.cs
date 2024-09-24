using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.QueryServices;

/**
 * TicketQueryService class
 * Represents a service for tickets
 * A ticket is a request for help from a user
 * A ticket can be assigned to a customer support agent
 */
public class TicketQueryService(ITicketRepository ticketRepository)
    : ITicketQueryService
{
    public async Task<Ticket?> Handle(GetTicketByTicketIdQuery query)
    {
        return await ticketRepository.FindByIdAsync(query.TicketId);
    }
    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsByUserIdQuery query)
    {
        return await ticketRepository.FindByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsByCustomerSupportAgentIdQuery query)
    {
        return await ticketRepository.FindByCustomerSupportAgentIdAsync(query.CustomerSupportAgentId);
    }
}
