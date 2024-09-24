namespace EcoMoveAPI.UserManagement.Domain.Model.Commands;

/**
 * <summary>
 * Represents the command to sign up a user. 
 * </summary>
 * <remarks>
 * This record is used to transfer the data needed to sign up a user.
 * </remarks>
 */

public record SignUpCommand(string FirstName, string LastName, string Email, string Username, string Password);