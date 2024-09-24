using EcoMoveAPI.CustomerSupport.Domain.Model.Entities;
using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;

/**
 * Ticket class
 * Represents a ticket
 * A ticket is a request for customer support
 */

public partial class Ticket
{
  public Ticket()
  {
    Title = string.Empty;
    Description = string.Empty;
    Status = string.Empty;
  }
  
  public Ticket(string title, string description, int ticketCategoryId, string status, int customerSupportAgentId, int userId)
  {
    Title = title;
    Description = description;
    TicketCategoryId = ticketCategoryId;
    Status = status;
    CustomerSupportAgentId = customerSupportAgentId;
    UserId = userId;
  }
  
  
  public int TicketId { get; private set; }
  public string Title { get; private set; }
  public string Description { get; private set; }
  public TicketCategory TicketCategory { get; internal set; }
  public int TicketCategoryId { get; private set; }
  public string Status { get; private set; }
  public CustomerSupportAgent CustomerSupportAgent { get; internal set; }
  public int CustomerSupportAgentId { get; private set; }
  public User User { get; internal set; }
  public int UserId { get; private set; }
}