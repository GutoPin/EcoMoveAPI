using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.Domain.Model.Queries;

namespace EcoMoveAPI.BlogManagment.Domain.Services;

public interface IBlogQueryService
{
    Task<IEnumerable<Blog>> Handle(GetAllBlogsQuery query);
    Task<IEnumerable<Blog>> Handle(GetAllBlogsByUserIdQuery query);
    Task<Blog?> Handle(GetBlogByBlogIdQuery query);
}