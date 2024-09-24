using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class MembershipResourceFromEntityAssembler
{
    public static MembershipResource ToResourceFromEntity(Membership entity)
    {
        return new MembershipResource(entity.UserId, entity.UserId, entity.MembershipCategoryId);
    }
}