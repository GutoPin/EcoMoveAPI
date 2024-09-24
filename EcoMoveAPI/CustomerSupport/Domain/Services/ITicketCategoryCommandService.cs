using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ITicketCategoryCommandService
{
    public Task<TicketCategory?> Handle(CreateTicketCategoryCommand command);
}