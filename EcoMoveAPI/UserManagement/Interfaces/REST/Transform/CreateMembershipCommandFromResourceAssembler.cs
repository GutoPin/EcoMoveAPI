using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class CreateMembershipCommandFromResourceAssembler
{
    public static CreateMembershipCommand ToCommandFromResource(CreateMembershipResource resource)
    {
        return new CreateMembershipCommand(resource.UserId, resource.MembershipCategoryId);
    }
}