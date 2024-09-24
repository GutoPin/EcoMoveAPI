using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.CustomerSupport.Domain.Repositories;

public interface ICustomerSupportAgentRepository : IBaseRepository<CustomerSupportAgent>
{
    Task<CustomerSupportAgent?> FindCustomerSupportAgentByIdAsync(int customerSupportAgentId);
    
}