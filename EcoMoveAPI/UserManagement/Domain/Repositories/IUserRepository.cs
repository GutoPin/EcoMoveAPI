using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.UserManagement.Domain.Repositories;

/**
 * IUserRepository interface
 * Represents a repository for users
 * A user is a person who uses the system
 */
public interface IUserRepository: IBaseRepository<User>
{
    /**
     * <summary>
     * Find a user by username
     * </summary>
     * <param name="username">The username of the user</param>
     * <returns>The user</returns>
     */
    Task<User?> FindByUsernameAsync(string username);
    
    /**
     * <summary>
     * Check if a user exists by username
     * </summary>
     * <param name="username">The username of the user</param>
     * <returns>True if the user exists, false otherwise</returns>
     */
    bool ExistsByUsername(string username);
}