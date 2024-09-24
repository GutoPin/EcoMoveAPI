using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Interfaces.ACL.Services;

public class UserManagementContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IUserManagementContextFacade
{
    /**
     * Create a new user
     * <param name="firstName">The first name of the user</param>
     * <param name="lastName">The last name of the user</param>
     * <param name="email">The email of the user</param>
     * <param name="username">The username of the user</param>
     * <param name="password">The password of the user</param>
     */
    public async Task<int> CreateUser(string firstName, string lastName, string email, string username, string password)
    {
        var signUpCommand = new SignUpCommand(firstName, lastName, email, username, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.UserId ?? 0;
    }
    /**
     * Fetch the user id by username
     * <param name="username">The username of the user</param>
     * <returns>The user id</returns>
     */
    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.UserId ?? 0;
    }
    /**
     * Fetch the username by user id
     * <param name="userId">The user id</param>
     * <returns>The username of the user</returns>
     * 
     */
    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByUserIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
    
    /**
     * Fetch the user by user id
     * <param name="userId">The user id</param>
     * <returns>The user</returns>
     */
    public async Task<User?> FetchUserByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByUserIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        if (result == null)
        {
            return await Task<User>.FromResult<User?>(null);
        }
        return result;
    }
    
}