using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ITicketQueryService
{
    Task<Ticket?> Handle(GetTicketByTicketIdQuery query);
    Task<IEnumerable<Ticket>> Handle(GetAllTicketsByUserIdQuery query);
    Task<IEnumerable<Ticket>> Handle(GetAllTicketsByCustomerSupportAgentIdQuery query);
}