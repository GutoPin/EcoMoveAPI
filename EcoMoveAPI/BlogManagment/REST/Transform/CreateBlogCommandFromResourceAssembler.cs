using EcoMoveAPI.BlogManagment.Domain.Model.Commands;
using EcoMoveAPI.BlogManagment.REST.Resources;

namespace EcoMoveAPI.BlogManagment.REST.Transform;

public static class CreateBlogCommandFromResourceAssembler
{
    public static CreateBlogCommand ToCommandFromResource(CreateBlogResource resource)
    {
        return new CreateBlogCommand(resource.UserId, resource.Title, resource.Description);
    }
}