namespace EcoMoveAPI.CustomerSupport.Domain.Model.Commands;

/**
 * Command to create a ticket.
 * <param name="Title">The title of the ticket.</param>
 * <param name="Description">The description of the ticket.</param>
 * <param name="TicketCategoryId">The ticket</param>
 * <param name="Status">The status of the ticket.</param>
 * <param name="CustomerSupportAgentId">The customer support agent id.</param>
 * <param name="UserId">The user id.</param>
 * <returns>The command to create a ticket.</returns>
 */
public record CreateTicketCommand(
    string Title,
    string Description,
    int TicketCategoryId,
    string Status,
    int CustomerSupportAgentId,
    int UserId);