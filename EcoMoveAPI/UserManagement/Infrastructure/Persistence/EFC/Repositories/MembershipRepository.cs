using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.UserManagement.Infrastructure.Persistence.EFC.Repositories;

public class MembershipRepository(AppDbContext context): BaseRepository<Membership>(context), IMembershipRepository
{
    public async Task<Membership?> FindMembershipByIdAsync(int membershipId)
    {
        return await Context.Set<Membership>().FirstOrDefaultAsync(membership => membership.MembershipId == membershipId);
    }
    
    public async Task<Membership?> FindByUserIdAsync(int userId)
    {
        return await Context.Set<Membership>().OrderByDescending(membership => membership.CreatedDate).FirstOrDefaultAsync(membership => membership.UserId == userId);
    }
}