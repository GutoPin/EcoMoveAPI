using System.Text.Json.Serialization;
using EcoMoveAPI.BookingReservation.Domain.Model.Aggregates;
using EcoMoveAPI.CustomerSupport.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.UserManagement.Domain.Model.ValueObjects;

namespace EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

/**
 * User class
 * Represents a user in the system
 * A user can have multiple memberships, bookings and tickets
 */
public partial class User
{
    public User()
    {
        Name = new PersonName();
        Username = string.Empty;
        Email = new EmailAddress();
        PasswordHash = string.Empty;
    }
    
    
    public User(string firstName, string lastName, string email, string username, string passwordHash)
    {
        Name = new PersonName(firstName, lastName);
        Username = username;
        Email = new EmailAddress(email);
        PasswordHash = passwordHash;
    }
    
    public int UserId { get; }
    public PersonName Name { get; private set; }
    public string Username { get; private set; }
    public EmailAddress Email { get; private set; }
    [JsonIgnore] public string PasswordHash { get; private set; }
    
    public string FullName => Name.FullName;
    
    public string EmailAddress => Email.Address;
    
    public ICollection<Membership> Memberships { get; }
    
    public ICollection<Booking> Bookings { get; }
    
    public ICollection<Ticket> Tickets { get; }
    
    public ICollection<Transaction> Transactions { get; }
    
}