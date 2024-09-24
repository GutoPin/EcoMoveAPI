using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class CreateCustomerSupportAgentCommandFromResourceAssembler
{
    public static CreateCustomerSupportAgentCommand ToCommandFromResource(CreateCustomerSupportAgentResource resource)
    {
        return new CreateCustomerSupportAgentCommand(resource.FirstName, resource.LastName, resource.Email);
    }
}