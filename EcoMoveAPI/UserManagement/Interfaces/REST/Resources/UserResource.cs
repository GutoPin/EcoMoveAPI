namespace EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

public record UserResource(int UserId, string FullName, string Email, string Username);