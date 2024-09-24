using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Application.Internal.QueryServices;

/**
 * <summary>
 *    The user query service implementation class
 * </summary>
 * <remarks>
 *   This class is used to handle user queries
 * </remarks>
 */

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /**
     * <summary>
     *   Handle get user by id query
     * </summary>
     * <param name="query">The query object containing the user id to search</param>
     * <returns>The user</returns>
     */

    public async Task<User?> Handle(GetUserByUserIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
    /**
     * <summary>
     *   Handle get user by username query
     * </summary>
     * <param name="query">The query object containing the user id to search</param>
     * <returns>The user</returns>
     */
    public async Task<User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
    
    
}