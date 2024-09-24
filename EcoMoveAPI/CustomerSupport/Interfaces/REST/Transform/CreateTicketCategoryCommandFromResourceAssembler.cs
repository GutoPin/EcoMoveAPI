using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class CreateTicketCategoryCommandFromResourceAssembler
{
    public static CreateTicketCategoryCommand ToCommandFromResource(CreateTicketCategoryResource resource)
    {
        return new CreateTicketCategoryCommand(resource.Name);
    }
}