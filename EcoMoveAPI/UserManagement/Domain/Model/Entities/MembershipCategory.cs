using EcoMoveAPI.UserManagement.Domain.Model.Aggregates;

namespace EcoMoveAPI.UserManagement.Domain.Model.Entities;

/**
 * MembershipCategory class
 * Represents a membership category
 * A membership category is a type of membership
 */
public class MembershipCategory
{
    public MembershipCategory()
    {
        Name = string.Empty;
    }

    public MembershipCategory(string name)
    {
        Name = name;
    }
    
    public int MembershipCategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Membership> Memberships { get; }
}