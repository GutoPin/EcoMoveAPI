namespace EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

/**
 * Query to get ticket by ticket id.
 * <param name="TicketId">The ticket id.</param>
 * <returns>The query to get ticket by ticket id.</returns>
 */
public record GetTicketByTicketIdQuery(int TicketId);