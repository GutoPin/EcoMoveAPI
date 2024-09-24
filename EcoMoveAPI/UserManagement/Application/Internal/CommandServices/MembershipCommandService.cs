using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Application.Internal.CommandServices;

/**
 * This class is responsible for handling membership commands.
 * <param name="membershipRepository">The membership repository.</param>
 * <param name="userRepository">The user repository.</param>
 * <param name="membershipCategoryRepository">The membership category repository.</param>
 * <param name="unitOfWork">The unit of work for the database.</param>
 * <remarks>
 * This class implements the IMembershipCommandService interface.
 * </remarks>
 */
public class MembershipCommandService(IMembershipRepository membershipRepository, IUserRepository userRepository, IMembershipCategoryRepository membershipCategoryRepository, IUnitOfWork unitOfWork) : IMembershipCommandService
{
    /** 
     * Handle the command to create a new membership.
     * <param name="command">The command to create a new membership.</param>
     * <returns>The newly created membership.</returns>
     */
    public async Task<Membership?> Handle(CreateMembershipCommand command)
    {
        var membership = new Membership(command.UserId, command.MembershipCategoryId);
        await membershipRepository.AddAsync(membership);
        await unitOfWork.CompleteAsync();
        var user = await userRepository.FindByIdAsync(command.UserId);
        membership.User = user;
        var membershipCategory = await membershipCategoryRepository.FindByIdAsync(command.MembershipCategoryId);
        membership.MembershipCategory = membershipCategory;
        return membership;
    }
}
