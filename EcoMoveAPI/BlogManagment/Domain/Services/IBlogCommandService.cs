using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.Domain.Model.Commands;

namespace EcoMoveAPI.BlogManagment.Domain.Services;

public interface IBlogCommandService
{
    Task<Blog?> Handle(CreateBlogCommand command);
}