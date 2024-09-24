using EcoMoveAPI.UserManagement.Domain.Model.Entities;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class MembershipCategoryResourceFromEntityAssembler
{
    public static MembershipCategoryResource ToResourceFromEntity(MembershipCategory entity)
    {
        return new MembershipCategoryResource(entity.MembershipCategoryId, entity.Name);
    }
}