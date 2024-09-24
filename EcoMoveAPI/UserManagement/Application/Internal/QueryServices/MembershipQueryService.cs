using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.Queries;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using EcoMoveAPI.UserManagement.Domain.Services;

namespace EcoMoveAPI.UserManagement.Application.Internal.QueryServices;

/**
 * MembershipQueryService is a class that implements the IMembershipQueryService interface.
 * <param name="membershipRepository">The membership repository.</param>
 */
public class MembershipQueryService(IMembershipRepository membershipRepository): IMembershipQueryService
{
    public async Task<Membership?> Handle(GetMembershipByMembershipIdQuery query)
    {
        return await membershipRepository.FindByIdAsync(query.MembershipId);
    }
    
    public async Task<Membership?> Handle(GetMembershipByUserIdQuery query)
    {
        return await membershipRepository.FindByUserIdAsync(query.UserId);
    }
}