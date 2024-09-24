namespace EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

/**
 * Query to get all tickets by customer support agent id.
 * <param name="CustomerSupportAgentId">The customer support agent id.</param>
 * <returns>The query to get all tickets by customer support agent id.</returns>
 */
public record GetAllTicketsByCustomerSupportAgentIdQuery(int CustomerSupportAgentId);