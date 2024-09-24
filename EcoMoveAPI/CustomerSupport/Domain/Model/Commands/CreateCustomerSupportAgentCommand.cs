namespace EcoMoveAPI.CustomerSupport.Domain.Model.Commands;


/**
 * Command to create a customer support agent.
 * <param name="FirstName">The first name of the customer support agent.</param>
 * <param name="LastName">The last name of the customer support agent.</param>
 * <param name="Email">The email of the customer support agent.</param>
 * <returns>The command to create a customer support agent.</returns>
 */
public record CreateCustomerSupportAgentCommand(string FirstName, string LastName, string Email);