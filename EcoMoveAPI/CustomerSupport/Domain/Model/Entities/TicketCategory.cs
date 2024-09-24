using System.ComponentModel;
using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;

namespace EcoMoveAPI.CustomerSupport.Domain.Model.Entities;

/**
 * <summary>
 * Represents a category of tickets.
 * A ticket category is a type of ticket.
 * </summary>
 */
public class TicketCategory
{
    public TicketCategory()
    {
        Name = string.Empty;
    }

    public TicketCategory(string name)
    {
        Name = name;
    }
    
    public int TicketCategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Ticket> Tickets { get; }
}