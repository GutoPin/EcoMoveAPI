using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.CustomerSupport.Domain.Repositories;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using EcoMoveAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace EcoMoveAPI.CustomerSupport.Infrastructure.Persistence.EFC.Repositories;

public class TicketCategoryRepository(AppDbContext context)
    : BaseRepository<TicketCategory>(context), ITicketCategoryRepository;
