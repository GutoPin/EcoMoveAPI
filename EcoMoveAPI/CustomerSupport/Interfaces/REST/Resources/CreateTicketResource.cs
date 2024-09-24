namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

public record CreateTicketResource(string Title, string Description, int TicketCategoryId, string Status, int CustomerSupportAgentId, int UserId);