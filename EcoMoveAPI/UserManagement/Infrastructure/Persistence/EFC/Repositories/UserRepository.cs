using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.UserManagement.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }
    
    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}