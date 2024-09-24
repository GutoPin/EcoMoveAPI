using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}