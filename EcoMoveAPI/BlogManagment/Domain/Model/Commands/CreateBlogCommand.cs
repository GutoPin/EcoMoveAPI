namespace EcoMoveAPI.BlogManagment.Domain.Model.Commands;

public record CreateBlogCommand(int UserId, string Title, string Description);