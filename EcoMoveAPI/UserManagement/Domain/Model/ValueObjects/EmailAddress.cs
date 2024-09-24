namespace EcoMoveAPI.UserManagement.Domain.Model.ValueObjects;

/**
 * Value object for an email address.
 * <param name="Address">The address of the email.</param>
 * <remarks>
 * This value object is used to represent an email address.
 * </remarks>
 * <returns>The email address with the specified address.</returns>
 */
public record EmailAddress(string Address)
{
    public EmailAddress(): this(string.Empty){}
}