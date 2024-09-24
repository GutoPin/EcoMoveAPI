namespace EcoMoveAPI.UserManagement.Interfaces.REST.Resources;

public record SignUpResource(string FirstName, string LastName, string Email, string Username, string Password);