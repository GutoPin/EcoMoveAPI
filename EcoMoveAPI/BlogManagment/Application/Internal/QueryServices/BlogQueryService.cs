using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.Domain.Model.Queries;
using EcoMoveAPI.BlogManagment.Domain.Repositories;
using EcoMoveAPI.BlogManagment.Domain.Services;

namespace EcoMoveAPI.BlogManagment.Application.Internal.QueryServices;

public class BlogQueryService(IBlogRepository blogRepository) : IBlogQueryService
{
    public async Task<IEnumerable<Blog>> Handle(GetAllBlogsQuery query)
    {
        return await blogRepository.ListAsync();
    }

    public async Task<IEnumerable<Blog>> Handle(GetAllBlogsByUserIdQuery query)
    {
        return await blogRepository.FindAllBlogsByUserIdAsync(query.UserId);
    }

    public async Task<Blog?> Handle(GetBlogByBlogIdQuery query)
    {
        return await blogRepository.FindBlogByIdAsync(query.BlogId);
    }
}