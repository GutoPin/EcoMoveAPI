using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Application.Internal.OutboundServices;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Application.Internal.CommandServices;

/**
 * This class is responsible for handling user commands.
 * <param name="userRepository">The user repository.</param>
 * <param name="tokenService">The token service.</param>
 * <param name="hashingService">The hashing service.</param>
 * <param name="unitOfWork">The unit of work for the database.</param>
 * <remarks>
 * This class implements the IUserCommandService interface.
 * </remarks>
 */
public class UserCommandService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IHashingService hashingService,
    IUnitOfWork unitOfWork)
    : IUserCommandService
{
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByUsernameAsync(command.Username);

        if (user == null || !hashingService.VerifyPassword(command.Password, user.PasswordHash))
            throw new Exception("Invalid username or password");

        var token = tokenService.GenerateToken(user);

        return (user, token);
    }

    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByUsername(command.Username))
            throw new Exception($"Username {command.Username} is already taken");
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command.FirstName, command.LastName, command.Email, command.Username, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception("$An error occurred while creating the user: {e.Message}");
        }
    }
}