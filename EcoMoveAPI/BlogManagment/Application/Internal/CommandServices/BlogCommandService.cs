using EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;
using EcoMoveAPI.BlogManagment.Domain.Model.Commands;
using EcoMoveAPI.BlogManagment.Domain.Repositories;
using EcoMoveAPI.BlogManagment.Domain.Services;
using EcoMoveAPI.Shared.Application.Internal.OutboundServices;
using EcoMoveAPI.Shared.Domain.Repositories;

namespace EcoMoveAPI.BlogManagment.Application.Internal.CommandServices;

public class BlogCommandService(IBlogRepository blogRepository, IUnitOfWork unitOfWork, ExternalUserService externalUserService) : IBlogCommandService
{
    public async Task<Blog?> Handle(CreateBlogCommand command)
    {
        var blog = new Blog(command);
        try
        {
            var user = await externalUserService.FetchUserByUserId(command.UserId);
            blog.User = user;
            await blogRepository.AddAsync(blog);
            await unitOfWork.CompleteAsync();
            return blog;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the blog: {e.Message}");
            return null;
        }
    }
}