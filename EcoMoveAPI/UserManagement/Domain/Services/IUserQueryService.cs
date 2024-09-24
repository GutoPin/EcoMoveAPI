using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;

namespace EcoMoveAPI.UserManagement.Domain.Services;

public interface IUserQueryService
{
    /**
     * <summary>
     *   Handle get user by user id query
     * </summary>
     * <param name="query">The query object containing the user id to search</param>
     * <returns>The user</returns>
     */
    Task<User?> Handle(GetUserByUserIdQuery query);
    
    /**
     * <summary>
     *   Handle get user by username query
     * </summary>
     * <param name="query">The query object containing the username to search</param>
     * <returns>The user</returns>
     */
    Task<User?> Handle(GetUserByUsernameQuery query);
}