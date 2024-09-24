using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class CreateTicketCommandFromResourceAssembler
{
    public static CreateTicketCommand ToCommandFromResource(CreateTicketResource resource)
    {
        return new CreateTicketCommand(resource.Title, resource.Description, resource.TicketCategoryId, resource.Status, resource.CustomerSupportAgentId, resource.UserId);
    }
}