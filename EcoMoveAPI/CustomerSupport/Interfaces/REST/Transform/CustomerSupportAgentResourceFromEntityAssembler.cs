using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class CustomerSupportAgentResourceFromEntityAssembler
{
    public static CustomerSupportAgentResource ToResourceFromEntity(CustomerSupportAgent entity)
    {
        return new CustomerSupportAgentResource(entity.CustomerSupportAgentId, entity.FullName, entity.EmailAddress);
    }
}