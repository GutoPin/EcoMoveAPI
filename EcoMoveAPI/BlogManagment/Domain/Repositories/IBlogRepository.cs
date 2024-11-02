using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.BlogManagment.Domain.Repositories;

public interface IBlogRepository : IBaseRepository<Blog>
{
    Task<Blog?> FindBlogByIdAsync(int blog);
    Task<IEnumerable<Blog>> FindAllBlogsByUserIdAsync(int userId);
}