using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ICustomerSupportAgentQueryService
{
    Task<CustomerSupportAgent?> Handle(GetCustomerSupportAgentByCustomerSupportAgentIdQuery query);
}