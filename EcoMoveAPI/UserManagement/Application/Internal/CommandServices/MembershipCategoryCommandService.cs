using EcoMoveAPI.Shared.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Model.Entities;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Application.Internal.CommandServices;

/**
 * Service for handling commands related to membership categories.
 * <summary>
 *  This service is used to handle the commands related to membership categories.
 * </summary>
 * <remarks>
 * This class implements the IMembershipCategoryCommandService interface.
 * </remarks>
 */
public class MembershipCategoryCommandService(IMembershipCategoryRepository membershipCategoryRepository, IUnitOfWork unitOfWork) : IMembershipCategoryCommandService
{
    /**
     * Handle the command to create a new membership category.
     * <param name="command">The command to create a new membership category.</param>
     * <returns>The newly created membership category.</returns>
     */
    public async Task<MembershipCategory?> Handle(CreateMembershipCategoryCommand command)
    {
        var membershipCategory = new MembershipCategory(command.Name);
        await membershipCategoryRepository.AddAsync(membershipCategory);
        await unitOfWork.CompleteAsync();
        return membershipCategory;
    }    
}