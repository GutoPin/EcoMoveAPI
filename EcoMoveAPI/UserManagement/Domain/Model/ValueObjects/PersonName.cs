namespace EcoMoveAPI.UserManagement.Domain.Model.ValueObjects;

/**
 * Value object for a person's name.
 * <param name="FirstName">The first name of the person.</param>
 * <param name="LastName">The last name of the person.</param>
 * <remarks>
 * This value object is used to represent a person's name.
 * </remarks>
 */
public record PersonName(string FirstName, string LastName)
{
    public PersonName() : this(string.Empty, string.Empty)
    {
    }

    public PersonName(string firstName) : this(firstName, string.Empty)
    {
    }

    public string FullName => $"{FirstName} {LastName}";
}