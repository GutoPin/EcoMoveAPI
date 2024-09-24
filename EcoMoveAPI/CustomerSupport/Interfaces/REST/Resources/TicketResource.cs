namespace EcoMoveAPI.CustomerSupport.Interfaces.REST.Resources;

public record TicketResource(int Id, string Title, string Description, int TicketCategoryId, string Status, int CustomerSupportAgentId, int UserId);