namespace EcoMoveAPI.BlogManagment.REST.Resources;

public record CreateBlogResource(string Title, string Description, int UserId);