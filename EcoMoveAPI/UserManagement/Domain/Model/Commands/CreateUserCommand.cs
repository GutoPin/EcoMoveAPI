namespace EcoMoveAPI.UserManagement.Domain.Model.Commands;

/**
 * Command to create a user.
 * <param name="FirstName">The first name of the user.</param>
 * <param name="LastName">The last name of the user.</param>
 * <param name="Email">The email of the user.</param>
 * <remarks>
 * This command is used to create a user.
 * </remarks>
 */
public record CreateUserCommand(string FirstName, string LastName, string Email);