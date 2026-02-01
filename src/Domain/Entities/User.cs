using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{

    protected User() { }

    public User(string firstName, string lastName, string email)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));

        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; set; }


    public virtual ICollection<Order> Orders { get; private set; } = new List<Order>();

}