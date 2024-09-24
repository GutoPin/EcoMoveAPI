using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.CommandServices;

/**
 * This class is responsible for handling the business logic of the CustomerSupportAgent entity.
 * It implements the ICustomerSupportAgentCommandService interface.
 * It has a constructor that receives an ICustomerSupportAgentRepository and an IUnitOfWork.
 */
public class CustomerSupportAgentCommandService(ICustomerSupportAgentRepository customerSupportAgentRepository, IUnitOfWork unitOfWork)
    : ICustomerSupportAgentCommandService
{
    /**
     * This method is responsible for handling the business logic of creating a CustomerSupportAgent entity.
     * <param name="command">The CreateCustomerSupportAgentCommand</param>
     * <returns>The CustomerSupportAgent</returns>
     */
    public async Task<CustomerSupportAgent?> Handle(CreateCustomerSupportAgentCommand command)
    {
        var customerSupportAgent = new CustomerSupportAgent(command.FirstName, command.LastName, command.Email);
        await customerSupportAgentRepository.AddAsync(customerSupportAgent);
        await unitOfWork.CompleteAsync();
        return customerSupportAgent;
    }
}