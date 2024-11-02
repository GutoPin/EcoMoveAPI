using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMoveAPI.BlogManagment.Infrastructure.Persistence.EFC.Repositories;

public class BlogRepository(AppDbContext context) : BaseRepository<Blog>(context), IBlogRepository
{
    public Task<Blog?> FindBlogByIdAsync(int blog)
    {
        return Context.Set<Blog>().Where(b => b.BlogId == blog).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Blog>> FindAllBlogsByUserIdAsync(int userId)
    {
        return await Context.Set<Blog>().Where(b => b.UserId == userId).ToListAsync();
    }
}