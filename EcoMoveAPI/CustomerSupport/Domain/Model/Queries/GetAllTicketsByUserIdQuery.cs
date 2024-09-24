namespace EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

/**
 * Query to get all tickets by user id.
 * <param name="UserId">The user id.</param>
 * <returns>The query to get all tickets by user id.</returns>
 */
public record GetAllTicketsByUserIdQuery(int UserId);