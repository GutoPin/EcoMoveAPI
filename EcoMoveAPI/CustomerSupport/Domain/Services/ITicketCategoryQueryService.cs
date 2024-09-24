using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.CustomerSupport.Domain.Model.Queries;

namespace EcoMoveAPI.CustomerSupport.Domain.Services;

public interface ITicketCategoryQueryService
{
    Task<TicketCategory?> Handle(GetTicketCategoryByTicketCategoryIdQuery query);
}