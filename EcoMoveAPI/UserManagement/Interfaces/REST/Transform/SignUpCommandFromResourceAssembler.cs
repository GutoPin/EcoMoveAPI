using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

namespace EcoMoveAPI.UserManagement.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.FirstName, resource.LastName, resource.Email, resource.Username,
            resource.Password);
    }
}