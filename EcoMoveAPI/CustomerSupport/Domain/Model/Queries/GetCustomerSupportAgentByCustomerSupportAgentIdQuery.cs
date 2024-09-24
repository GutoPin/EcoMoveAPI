namespace EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

/**
 * Query to get customer support agent by customer support agent id.
 * <param name="CustomerSupportAgentId">The customer support agent id.</param>
 * <returns>The query to get customer support agent by customer support agent id.</returns>
 */
public record GetCustomerSupportAgentByCustomerSupportAgentIdQuery(int CustomerSupportAgentId);