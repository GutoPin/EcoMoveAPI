using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ICustomerSupportAgentCommandService
{
    public Task<CustomerSupportAgent?> Handle(CreateCustomerSupportAgentCommand command);
}