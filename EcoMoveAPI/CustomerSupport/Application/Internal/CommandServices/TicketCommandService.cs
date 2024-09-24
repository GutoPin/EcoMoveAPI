using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;
using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Repositories;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.CommandServices;

/**
 * This class is responsible for handling the business logic of the Ticket entity.
 * <param name="ticketRepository">The ITicketRepository</param>
 * <param name="ticketCategoryRepository">The ITicketCategoryRepository</param>
 * <param name="customerSupportAgentRepository">The ICustomerSupportAgentRepository</param>
 * <param name="userRepository">The IUserRepository</param>
 * <param name="unitOfWork">The IUnitOfWork</param>
 * It implements the ITicketCommandService interface.
 */
public class TicketCommandService(ITicketRepository ticketRepository, ITicketCategoryRepository ticketCategoryRepository, ICustomerSupportAgentRepository customerSupportAgentRepository, IUserRepository userRepository,  IUnitOfWork unitOfWork)
    : ITicketCommandService
{
    /**
     * This method is responsible for handling the business logic of creating a Ticket entity.
     * <param name="command">The CreateTicketCommand</param>
     * <returns>The Ticket</returns>
     */
    public async Task<Ticket?> Handle(CreateTicketCommand command)
    {
        var ticket = new Ticket(command.Title, command.Description, command.TicketCategoryId, command.Status,
            command.CustomerSupportAgentId, command.UserId);
        await ticketRepository.AddAsync(ticket);
        await unitOfWork.CompleteAsync();
        var ticketCategory = await ticketCategoryRepository.FindByIdAsync(command.TicketCategoryId);
        ticket.TicketCategory = ticketCategory;
        var customerSupportAgent = await customerSupportAgentRepository.FindByIdAsync(command.CustomerSupportAgentId);
        ticket.CustomerSupportAgent = customerSupportAgent;
        var user = await userRepository.FindByIdAsync(command.UserId);
        ticket.User = user;
        return ticket;
    }
}