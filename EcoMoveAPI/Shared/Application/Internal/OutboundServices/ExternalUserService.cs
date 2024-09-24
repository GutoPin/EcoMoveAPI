using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Interfaces.ACL;
using EcoMoveAPI.UserManagement.Interfaces.ACL.Services;

namespace EcoMoveAPI.Shared.Application.Internal.OutboundServices;

/**
 * This class is responsible for fetching user information from the user management context facade.
 * <param name="userManagementContextFacade">The user management context facade.</param>
 * <remarks>
 * This class implements the IUserService interface.
 * </remarks>
 */
public class ExternalUserService(IUserManagementContextFacade userManagementContextFacade)
{
    public async Task<User> FetchUserByUserId(int userId)
    {
        var user = await userManagementContextFacade.FetchUserByUserId(userId);
        if (user == null)
        {
            return await Task<User>.FromResult<User?>(null);
        }
        return user;
    }
}

    