using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.CommandServices;

/**
 * This class is responsible for handling the business logic of the TicketCategory entity.
 */
public class TicketCategoryCommandService(ITicketCategoryRepository ticketCategoryRepository, IUnitOfWork unitOfWork)
    : ITicketCategoryCommandService
{
    /**
     * This method is responsible for handling the business logic of creating a TicketCategory entity.
     * <param name="command">The CreateTicketCategoryCommand</param>
     * <returns>The TicketCategory</returns>
     */
    public async Task<TicketCategory?> Handle(CreateTicketCategoryCommand command)
    {
        var ticketCategory = new TicketCategory(command.Name);
        await ticketCategoryRepository.AddAsync(ticketCategory);
        await unitOfWork.CompleteAsync();
        return ticketCategory;
    }
}