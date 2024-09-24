using EcoMoveAPI.CustomerSupport.Domain.Model.Commands;
using EcoMoveAPI.CustomerSupport.Domain.Model.ValueObjects;

namespace EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;

/**
 * Represents a customer support agent.
 * A customer support agent is a person who provides support to users.
 */
public partial class CustomerSupportAgent
{
    public CustomerSupportAgent()
    {
        Name = new PersonName();
        Email = new EmailAddress();
    }

    public CustomerSupportAgent(string firstName, string lastName, string email)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
    }

    public CustomerSupportAgent(CreateCustomerSupportAgentCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
    }
    
    public int CustomerSupportAgentId { get; private set; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }
    
    public string FullName => Name.FullName;
    public string EmailAddress => Email.Address;
    
    public ICollection<Ticket> Tickets { get; }
}