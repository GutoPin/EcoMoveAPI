using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Transform;

public static class TicketCategoryResourceFromEntityAssembler
{
    public static TicketCategoryResource ToResourceFromEntity(TicketCategory entity)
    {
        return new TicketCategoryResource(entity.TicketCategoryId, entity.Name);
    }
}