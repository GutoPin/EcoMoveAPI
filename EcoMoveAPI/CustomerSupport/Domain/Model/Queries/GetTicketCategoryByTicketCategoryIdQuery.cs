namespace EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

/**
 * Query to get ticket category by ticket category id.
 * <param name="TicketCategoryId">The ticket category id.</param>
 * <returns>The query to get ticket category by ticket category id.</returns>
 */
public record GetTicketCategoryByTicketCategoryIdQuery(int TicketCategoryId);