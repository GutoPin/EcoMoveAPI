namespace EcoMoveAPI.UserManagement.Domain.Model.Commands;

/**
 * Command to sign in.
 * <param name="Username">The username of the user.</param>
 * <param name="Password">The password of the user.</param>
 * <remarks>
 * This command is used to sign in.
 * </remarks>
 */
public record SignInCommand(string Username, string Password);