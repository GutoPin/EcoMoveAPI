using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.QueryServices;

/**
 * This class is responsible for handling queries related to customer support agents.
 */
public class CustomerSupportAgentQueryService(ICustomerSupportAgentRepository customerSupportAgentRepository)
    : ICustomerSupportAgentQueryService
{
    public async Task<CustomerSupportAgent?> Handle(GetCustomerSupportAgentByCustomerSupportAgentIdQuery query)
    {
        return await customerSupportAgentRepository.FindByIdAsync(query.CustomerSupportAgentId);
    }
}