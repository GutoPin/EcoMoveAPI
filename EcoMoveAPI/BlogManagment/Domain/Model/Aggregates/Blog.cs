using EcoMoveAPI.BlogManagment.Domain.Model.Commands;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.BlogManagment.Domain.Model.Aggregates;

public partial class Blog
{
    public Blog()
    {
        Title = string.Empty;
        Description = string.Empty;
    }
    
    public Blog(string title, string description)
    {
        Title = title;
        Description = description;
    }
    
    public Blog(CreateBlogCommand command)
    {
        UserId = command.UserId;
        Title = command.Title;
        Description = command.Description;
    }
    
    public int BlogId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public User User { get; internal set; }
    public int UserId { get; private set; }
}