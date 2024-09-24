using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Entities;
using EcoMoveAPI.UserManagement.Domain.Repositories;

namespace EcoMoveAPI.UserManagement.Infrastructure.Persistence.EFC.Repositories;

public class MembershipCategoryRepository(AppDbContext context) : BaseRepository<MembershipCategory>(context), IMembershipCategoryRepository
{
    
}