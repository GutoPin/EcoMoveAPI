using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ITicketCommandService
{
    public Task<Ticket> Handle(CreateTicketCommand command);
}