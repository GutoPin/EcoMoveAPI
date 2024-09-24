using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class TicketResourceFromEntityAssembler
{
    public static TicketResource ToResourceFromEntity(Ticket entity)
    {
        return new TicketResource(entity.TicketId, entity.Title, entity.Description, entity.TicketCategoryId, entity.Status, entity.CustomerSupportAgentId, entity.UserId);
    }
}