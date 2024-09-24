namespace EcoMoveAPI.CustomerSupport.Domain.Model.Commands;

/**
 * Command to create a ticket category.
 * <param name="Name">The name of the ticket category.</param>
 * <returns>The command to create a ticket category.</returns>
 */
public record CreateTicketCategoryCommand(string Name);