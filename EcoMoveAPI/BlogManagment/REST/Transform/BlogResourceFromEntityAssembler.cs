using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.REST.Resources;

namespace EcoMoveAPI.BlogManagment.REST.Transform;

public static class BlogResourceFromEntityAssembler
{
    public static BlogResource ToResourceFromEntity(Blog entity)
    {
        return new BlogResource(entity.BlogId, entity.Title, entity.Description, entity.UserId);
    }
}