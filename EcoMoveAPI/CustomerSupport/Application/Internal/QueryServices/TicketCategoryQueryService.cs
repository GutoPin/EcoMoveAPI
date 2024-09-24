using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.CustomerSupport.Domain.Services;

namespace EcoMoveAPI.CustomerSupport.Application.Internal.QueryServices;

/**
 * TicketCategoryQueryService class
 * Represents a service for ticket categories
 * A ticket category is a type of ticket
 */
public class TicketCategoryQueryService(ITicketCategoryRepository ticketCategoryRepository)
    : ITicketCategoryQueryService
{
    public async Task<TicketCategory?> Handle(GetTicketCategoryByTicketCategoryIdQuery query)
    {
        return await ticketCategoryRepository.FindByIdAsync(query.TicketCategoryId);
    }
}