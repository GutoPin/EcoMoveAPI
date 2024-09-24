using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class CreateMembershipCategoryCommandFromResourceAssembler
{
    public static CreateMembershipCategoryCommand ToCommandFromResource(CreateMembershipCategoryResource resource)
    {
        return new CreateMembershipCategoryCommand(resource.Name);
    }
}